using assignment_Dataaccess.Models;
using assignment_Dataaccess.Models.Enities;
using assignment_Dataaccess.Models.Forms;
using Microsoft.EntityFrameworkCore;

namespace assignment_Dataaccess.Services
{
    public interface IProductService
    {
        Task CreateAsync(ProductForm product);
        Task<Products> ReadAsync();
        Task<Products> ReadAsyncById(int id);
        Task<IEnumerable<Products>> ReadAsyncByEmail(string epost);


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

        public Task<Products> ReadAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Products>> ReadAsyncByEmail(string epost)
        {
            throw new NotImplementedException();
        }

        public Task<Products> ReadAsyncById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
