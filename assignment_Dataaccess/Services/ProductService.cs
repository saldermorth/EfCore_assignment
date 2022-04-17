using assignment_Dataaccess.Models;
using assignment_Dataaccess.Models.Enities;
using assignment_Dataaccess.Models.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace assignment_Dataaccess.Services
{
    public interface IProductService
    {
        Task CreateAsync(ProductForm product);
        Task<ActionResult<IEnumerable<ProductForm>>> ReadAsync();
        Task<ProductForm> ReadAsyncById(int id);
        Task<bool> Delete(int id);



    }
    public class ProductService : IProductService
    {
        private readonly SqlContext _sqlContext;

        public ProductService(SqlContext sqlContext)
        {
            _sqlContext = sqlContext;
        }

        public async Task CreateAsync(ProductForm product)
        {

            if (!await _sqlContext.Products.AnyAsync(x => x.Name == product.ProductName))//Om vi inte hittar en product
            {             

                var categoryEnt = new CategorysEntity();

                if (!await _sqlContext.Categorys.AnyAsync(x => x.Id == product.CategoryId)) // If category not exists create it
                {
                    categoryEnt = new CategorysEntity
                    {
                        Id = product.CategoryId,
                        Name = product.ProductName

                    };
                }

                if (!await _sqlContext.Products.AnyAsync(x => x.Name == product.ProductName)) //If product name not already in db crate product
                {
                    var Product = new ProductsEntity
                    {
                        Category = categoryEnt,
                        Name = product.ProductName,
                        Description = product.Description,
                        Stock = product.Stock,
                        Vendor = product.VendorName
                    };
                    _sqlContext.Products.Add(Product);
                    await _sqlContext.SaveChangesAsync();
                }
                
            }
        }

        public async Task<bool> Delete(int id)
        {
            var productEntity = await _sqlContext.Products.FindAsync(id);
            if (productEntity != null)
            {
                _sqlContext.Products.Remove(productEntity);
                await _sqlContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<ActionResult<IEnumerable<ProductForm>>> ReadAsync()
        {
            var allProducts = new List<ProductForm>();

            foreach (var item in await _sqlContext.Products.Include(x => x.Category).ToListAsync())
                allProducts.Add(new ProductForm
                {
                    Id = item.Id,
                  ProductName = item.Name,
                  Description = item.Description,
                  Price = item.Price,
                  Stock = item.Stock,
                  CategoryId = item.Category.Id, 
                  CategoryName = item.Category.Name,
                  VendorName = item.Vendor                      
                });


            if (allProducts != null)
            {
                return allProducts;
            }

            return null!; 
        }

        

        public async Task<ProductForm> ReadAsyncById(int id)
        {

        

            var product =  await _sqlContext.Products.Include(x => x.Category).FirstAsync();

            var productForm = new ProductForm();

            if (product != null)
            {
               

                if (product != null)
                {
                    productForm = new ProductForm
                    {
                        CategoryId = product.CategoryId,
                        CategoryName = product.Category.Name,                        
                        Description = product.Description,
                        Price = product.Price,
                        ProductName = product.Name,
                        Stock = product.Stock,
                        VendorName = product.Vendor
                    };
                    return productForm;
                }
               
            }

            return null;

            
        }
    }
}
