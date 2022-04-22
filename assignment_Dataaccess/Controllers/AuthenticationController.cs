using assignment_Dataaccess.Models;
using assignment_Dataaccess.Models.Enities;
using assignment_Dataaccess.Models.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace assignment_Dataaccess.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly SqlContext _context;
        private readonly IConfiguration _configuration;

        public AuthenticationController(SqlContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp(CustomerForm form)
        {
            if (await _context.Customers.AnyAsync(x => x.Email == form.Email))
            {
                return new ConflictObjectResult("USer already exits");
            }
            var address = new AddressEntity 
            { City = form.City,
            Street = form.Street,
                ZipCode = form.ZipCode
            };

            var CustomerEntity = new CustomerEntity()
            {
                FirstName = form.FirstName,
                LastName = form.LastName,
                Email = form.Email,
                Address = address
            };
            CustomerEntity.CreateSecurePassword(form.Password);
            _context.Customers.Add(CustomerEntity);
            await _context.SaveChangesAsync();


            return new OkObjectResult("User created");
        }
        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn(SignInForm form)  
        {
            return null;
        }
    }
}
