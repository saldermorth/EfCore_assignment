using assignment_Dataaccess.Filters;
using assignment_Dataaccess.Models.Enities;
using assignment_Dataaccess.Models.Forms;
using assignment_Dataaccess.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace assignment_Dataaccess.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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
        
        public async Task<ActionResult<IEnumerable<ProductForm>>> GetAllCategories()
        {
            return await _productService.ReadAsync();
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
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, ProductForm product)
        {

            var result = await _productService.UpdateAsync(id, product);
            if (result)
            {
                return Ok("Product Updated successful");
            }
            return NoContent();
        }
        #endregion
       
        #region Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomerEntity(int id) 
        {
            var customerentity = await _productService.Delete(id);
            if (!customerentity)
            {
                return NotFound();
            }            

            return Ok($"Order with id: {id} removed.");
        }
        #endregion

    }
}
