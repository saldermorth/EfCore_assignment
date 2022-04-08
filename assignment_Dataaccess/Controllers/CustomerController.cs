using assignment_Dataaccess.Models;
using assignment_Dataaccess.Models.Enities;
using assignment_Dataaccess.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace assignment_Dataaccess.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
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
                    FirstName = "Gustav",
                    LastName = "Berg",
                    Email = "g@domain.com",
                    Address = new AddressEntity
                    {
                        
                        City = customer.City,
                        Street = customer.Street,
                        ZipCode = customer.ZipCode
                    }


                }) ;

                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
          


        }
        #endregion
        #region Read

        #endregion
        #region Update
        #endregion
        #region Delete
        #endregion
    }
}
