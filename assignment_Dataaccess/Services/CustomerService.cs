using assignment_Dataaccess.Controllers;
using assignment_Dataaccess.Models;
using assignment_Dataaccess.Models.Enities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace assignment_Dataaccess.Services
{
    public interface ICustomerService
    {
        Task CreateAsync(Models.Customer customer);
        Task<ActionResult<IEnumerable<CustomerForm>>> ReadAsync();       
        Task<CustomerForm> ReadAsyncByEmail(string epost);
        Task<bool> Delete(int id);
        Task<CustomerForm> UpdateAsync(int id, CustomerForm customer);
    }
    public class CustomerService : ICustomerService
    {
        private readonly SqlContext _sqlcontext;


        public CustomerService(SqlContext context)
        {
            _sqlcontext = context;

        }

        public async Task CreateAsync(Customer customer)
        {

            if (!await _sqlcontext.Customers.AnyAsync(x =>
            x.Email == customer.Email))//Går inte in i if satsen
            {
                var newAddress = new AddressEntity();
                //Todo kolla om adressen redan finns.
                var addressEntity = await _sqlcontext.Addresses.ToListAsync(); //TODO vad får den in .Om addressid finns använd det annars skapa
              
                if (addressEntity != null)
                {
                    foreach (var address in addressEntity)
                    {
                        if (address.Street == customer.Address.Street && address.City == customer.Address.City && address.ZipCode == customer.Address.ZipCode)
                        {
                            customer.Address = address;
                        }
                        else if( newAddress.Street == null)
                        {
                             newAddress = new AddressEntity
                            {
                                Street = customer.Address.Street,
                                ZipCode = customer.Address.ZipCode,
                                City = customer.Address.City,

                            };
                            _sqlcontext.Addresses.Add(newAddress);
                            await _sqlcontext.SaveChangesAsync();
                        }      
                    }               
                }                          


                    var customerEntity = new CustomerEntity
                    {
                        FirstName = customer.FirstName,
                        LastName = customer.LastName,
                        Email = customer.Email,
                        Address = customer.Address,
                        
                    };
                    _sqlcontext.Customers.Add(customerEntity);
                    await _sqlcontext.SaveChangesAsync();
                
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

        public async Task<ActionResult<IEnumerable<CustomerForm>>> ReadAsync()
        {
         
            var items = new List<CustomerForm>();

            foreach (var item in await _sqlcontext.Customers.Include(x => x.Address).ToListAsync())
                items.Add(new CustomerForm
                {
                    Id = item.Id,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Email = item.Email,
                    Street = item.Address.Street,
                    ZipCode = item.Address.ZipCode,
                    City = item.Address.City,

                });

            return items;


        }

        public async Task<CustomerForm> ReadAsyncByEmail(string email)
        {
            var customers = await ReadAsync();
            var foundCustomer = new CustomerForm();

            foreach (var customer in await _sqlcontext.Customers.Include(x => x.Address).ToListAsync())
            {
                if (await _sqlcontext.Customers.AnyAsync(x => x.Email == email))                   
                {
                    foundCustomer = new CustomerForm
                    {
                        FirstName = customer.FirstName,
                        LastName = customer.LastName,
                        Email = email,
                        City = customer.Address.City,
                        Street = customer.Address.Street,
                        ZipCode = customer.Address.ZipCode
                    };
                   
                }
                return foundCustomer;
            }
            return null;

        }

      

        public async Task<CustomerForm> UpdateAsync(int id, CustomerForm customer)
        {

            var items = await _sqlcontext.Customers.Include(x => x.Address).ToListAsync();

            var userEntity = items.FirstOrDefault(x => x.Id == id);


            if (userEntity != null)
            {
                userEntity.FirstName = customer.FirstName;
                userEntity.LastName = customer.LastName;
                userEntity.Email = customer.Email;                
                _sqlcontext.Entry(userEntity).State = EntityState.Modified;
                await _sqlcontext.SaveChangesAsync();
                var updatedCustomer = new CustomerForm
                {
                    Id = id,
                    FirstName = userEntity.FirstName,
                    LastName = userEntity.LastName,
                    Email = userEntity.Email,
                    City = userEntity.Address.City,
                    Street = userEntity.Address.Street,
                    ZipCode = userEntity.Address.ZipCode

                };
                return updatedCustomer;
            }

            return null!;
        }



    }
}
