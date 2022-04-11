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
    }
    public class CustomerService : ICustomerService
    {
        private readonly SqlContext _context;
       

        public CustomerService(SqlContext context)
        {
            _context = context;
            
        }

        public async Task CreateAsync(Customer customer)// Funkar nu men kommer dubbletter i address tabellen
        {


            if (!await _context.Customers.AnyAsync(x => 
            x.Email == customer.Email))//Går inte in i if satsen
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

      
        public async Task<ActionResult<IEnumerable<Customer>>> ReadAsync()
        {
           

            var items = new List<Customer>();

            foreach (var item in await _context.Customers.ToListAsync())
                items.Add(new Customer
                {
                    Id = item.Id,
                    FirstName = item.FirstName
                });

            return items;


        }

        public Task<IEnumerable<CustomerEntity>> ReadAsyncByEmail(string epost)
        {
            throw new NotImplementedException();
        }


        /*   // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductEntity>>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductEntity>> GetProductEntity(int id)
        {
            var productEntity = await _context.Products.FindAsync(id);

            if (productEntity == null)
            {
                return NotFound();
            }

            return productEntity;
        }*/

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
