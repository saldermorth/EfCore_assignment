using assignment_Dataaccess.Models;
using assignment_Dataaccess.Models.Forms;
using assignment_Dataaccess.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace assignment_Dataaccess.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        #region Create
        [HttpPost]
        public async Task CreateProduct(ProductForm products) //Om man vill kan man här konvertera objektet här
        {
            await _productService.CreateAsync(products);
        }
        #endregion
        #region Read
        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            return new OkObjectResult(await _productService.ReadAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.ReadAsyncById(id);
            if (product != null)
            {
                return new OkObjectResult(product);

               
            }
            return new NotFoundResult();
           
        }
        #endregion
        #region Update
        //TODO implement
        #endregion
        #region Delete
           #region Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomerEntity(int id) //TODO
        {
            //var customerEntity = await _productService.Delete(id);
            //if (customerEntity == null)
            //{
            //    return NotFound();
            //}

            //_context.Customers.Remove(customerEntity);
            //await _context.SaveChangesAsync();

            return NoContent();
        }
        #endregion
        #endregion

    }
}
