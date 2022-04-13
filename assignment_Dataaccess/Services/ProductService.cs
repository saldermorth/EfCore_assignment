using assignment_Dataaccess.Models;
using assignment_Dataaccess.Models.Enities;
using Microsoft.EntityFrameworkCore;

namespace assignment_Dataaccess.Services
{
    public interface IProductService
    {
        Task CreateAsync(Products product);
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

        public async Task CreateAsync(Products product)
        {
         
            if(!await _sqlContext.Products.AnyAsync(x => x.Name == product.Name))//Om vi inte hittar en användare
            {
                //var vendor = await _sqlContext.Vendors.FirstOrDefaultAsync(x => x.Id == product.Vendors.Id); //Vi kollar om det finns någon vendor
                //if (vendor == null)//Annars skapar vi en
                //{
                //    vendor = new VendorsEntity
                //    {
                //        Name = product.Vendors.Name,
                //        Id = product.Vendors.Id//Och sätter in värdena vi behöver till vendors tabellen
                //    };
                //    _sqlContext.Vendors.Add(vendor);//category products null och krockar med FK_Products_Orders_orderID borde inte behöva ngt i order tabellen hära
                //    await _sqlContext.SaveChangesAsync();
                //}

                var Product = new ProductsEntity
                {
                    Name = product.Name,
                    Description = product.Description,
                    Stock = product.Stock,
                    //Vendors = product.
                    
                };
                _sqlContext.Products.Add(Product);
                await _sqlContext.SaveChangesAsync();
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
