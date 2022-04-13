using assignment_Dataaccess.Models;
using assignment_Dataaccess.Models.Enities;
using assignment_Dataaccess.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace assignment_Dataaccess.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly SqlContext _context;
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService, SqlContext context)
        {
            _customerService = customerService;
            _context = context;
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

    

        #endregion
        #region Update
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, CustomerEntity category)
        {
            if (id != category.Id)
            {
                return BadRequest();
            }

            _context.Entry(category).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.Id == id);
        }

        

        #endregion
        #region Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomerEntity(int id)
        {
            var customerEntity = await _context.Customers.FindAsync(id);
            if (customerEntity == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(customerEntity);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        #endregion
    }
}
