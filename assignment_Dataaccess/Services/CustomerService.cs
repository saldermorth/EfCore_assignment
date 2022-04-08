using assignment_Dataaccess.Models;

namespace assignment_Dataaccess.Services
{
    public interface ICustomerService
    {
        Task CreateAsync(Customer product);
        Task<Customer> ReadAsync();
        Task<Customer> ReadAsyncById(int id);
        Task<IEnumerable<Customer>> ReadAsyncByEmail(string epost);
    }
    public class CustomerService : ICustomerService
    {
        public Task CreateAsync(Customer product)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> ReadAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Customer>> ReadAsyncByEmail(string epost)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> ReadAsyncById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
