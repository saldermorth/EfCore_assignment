using assignment_Dataaccess.Filters;
using assignment_Dataaccess.Models;
using assignment_Dataaccess.Models.Enities;
using assignment_Dataaccess.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace assignment_Dataaccess.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [UseApiKey]
    public class CustomerController : ControllerBase
    {
        private readonly SqlContext _context;
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService, SqlContext context)
        {
            _customerService = customerService;
            _context = context; //To do ta bort
        }


        

        #region Create
        [HttpPost]
        public async Task<ActionResult> CreateProduct(CustomerForm customer) //Om man vill kan man här konvertera objektet här
        {
            try
            {
                await _customerService.CreateAsync(new Customer
                {
                    Id = customer.Id,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    Email = customer.Email,
                    Address = new AddressEntity
                    {
                        City = customer.City,
                        Street = customer.Street,
                        ZipCode = customer.ZipCode
                    }
                });

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }



        }
        #endregion
        #region Read
        [HttpGet]
        
        public async Task<ActionResult<IEnumerable<Customer>>> Read()
        {           
                        return await _customerService.ReadAsync();
        }

        [HttpGet("{email}")]
        public async Task<ActionResult<CustomerForm>> ReadByEmail(string email)
        {
            return await _customerService.ReadAsyncByEmail(email);
        }

        #endregion
        #region Update
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, CustomerForm customer)
        {
            
          var result = await _customerService.UpdateAsync(id, customer);

          

            return NoContent();
        }

        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.Id == id);
        }

        

        #endregion
        #region Delete
        
        [HttpDelete("{id}")]
        
        public async Task<IActionResult> Delete(int id)
        {
            bool found = await _customerService.Delete(id);
            
            if (found)
            {
                return Ok($"Customer with id: {id} is deleted! ");
            }

            return NotFound();
            
        }
        #endregion
    }
}
