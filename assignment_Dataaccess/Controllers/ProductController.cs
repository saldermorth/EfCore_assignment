using assignment_Dataaccess.Models;
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
        public async Task CreateProduct(Products products) //Om man vill kan man här konvertera objektet här
        {
            await _productService.CreateAsync(products);
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
