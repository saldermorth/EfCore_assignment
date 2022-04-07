using assignment_Dataaccess.Models;

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
        
        public Task CreateAsync(Products product)
        {
            throw new NotImplementedException();
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
