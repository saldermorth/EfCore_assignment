using assignment_Dataaccess.Controllers;
using assignment_Dataaccess.Models;
using assignment_Dataaccess.Models.Enities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace assignment_Dataaccess.Services
{
    public interface ICustomerService
    {
        Task CreateAsync(Customer customer);
        Task<ActionResult<IEnumerable<Customer>>> ReadAsync();
        Task<Customer> ReadAsyncById(int id);
        Task<IEnumerable<Customer>> ReadAsyncByEmail(string epost);
        Task<bool> Delete(int id);
    }
    public class CustomerService : ICustomerService
    {
        private readonly SqlContext _sqlcontext;
       

        public CustomerService(SqlContext context)
        {
            _sqlcontext = context;
            
        }

        public async Task CreateAsync(Customer customer)// Funkar nu men kommer dubbletter i address tabellen
        {


            if (!await _sqlcontext.Customers.AnyAsync(x => 
            x.Email == customer.Email))//Går inte in i if satsen
            {
                var addressEntity = await _sqlcontext.Addresses.FirstOrDefaultAsync(x => x.Id == customer.Address.Id); //TODO vad får den in .Om addressid finns använd det annars skapa
                if (addressEntity == null)
                {
                    addressEntity = new AddressEntity
                    {
                        Street = customer.Address.Street,
                        ZipCode = customer.Address.ZipCode,
                        City = customer.Address.City,

                    };
                    _sqlcontext.Addresses.Add(addressEntity);
                    await _sqlcontext.SaveChangesAsync();


                    var customerEntity = new CustomerEntity
                    {
                        FirstName = customer.FirstName,
                        LastName = customer.LastName,
                        Email = customer.Email,
                        Address = customer.Address
                    };
                    _sqlcontext.Customers.Add(customerEntity);
                    await _sqlcontext.SaveChangesAsync();
                }
            }
        }

        public async Task<bool> Delete(int id)
        {
            var customerEntity = await _sqlcontext.Customers.FindAsync(id);
            if (customerEntity != null)
            {
                _sqlcontext.Customers.Remove(customerEntity);
                await _sqlcontext.SaveChangesAsync();
                return true;
            }

          

            return false;
        }

        public async Task<ActionResult<IEnumerable<Customer>>> ReadAsync()
        {
           

            var items = new List<Customer>();

            foreach (var item in await _sqlcontext.Customers.ToListAsync())
                items.Add(new Customer
                {
                    Id = item.Id,
                    FirstName = item.FirstName,
                    LastName= item.LastName,
                    Email= item.Email
                });

            return items;


        }

        public Task<IEnumerable<CustomerEntity>> ReadAsyncByEmail(string epost)
        {
            throw new NotImplementedException();
        }


      

        public Task<Customer> ReadAsyncById(int id)
        {
            throw new NotImplementedException();
        }

       

        Task<IEnumerable<Customer>> ICustomerService.ReadAsyncByEmail(string epost)
        {
            throw new NotImplementedException();
        }
    }
}
