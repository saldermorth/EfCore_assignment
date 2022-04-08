using assignment_Dataaccess.Models;
using assignment_Dataaccess.Models.Enities;
using Microsoft.EntityFrameworkCore;

namespace assignment_Dataaccess.Services
{
    public interface ICustomerService
    {
        Task CreateAsync(Customer customer);
        Task<Customer> ReadAsync();
        Task<Customer> ReadAsyncById(int id);
        Task<IEnumerable<Customer>> ReadAsyncByEmail(string epost);
    }
    public class CustomerService : ICustomerService
    {
        private readonly SqlContext _context;

        public CustomerService(SqlContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Customer customer)
        {
            if (!await _context.Customers.AnyAsync(x => x.FirstName == customer.FirstName))
            {
                var addressEntity = await _context.Addresses.FirstOrDefaultAsync(x => x.Id == customer.Address.Id); //TODO vad får den in .Om addressid finns använd det annars skapa
                if (addressEntity == null)
                {
                    addressEntity = new AddressEntity
                    {
                        Street = customer.Address.Street,
                        ZipCode = customer.Address.ZipCode,
                        City = customer.Address.City,

                    };
                    _context.Addresses.Add(addressEntity);
                    await _context.SaveChangesAsync();


                    var customerEntity = new CustomerEntity
                    {
                        FirstName = customer.FirstName,
                        LastName = customer.LastName,
                        Email = customer.Email,
                        Address = customer.Address
                    };
                    _context.Customers.Add(customerEntity);
                    await _context.SaveChangesAsync();
                }
            }
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
