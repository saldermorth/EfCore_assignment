using assignment_Dataaccess.Models;
using assignment_Dataaccess.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace assignment_Dataaccess.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        #region Create
        [HttpPost]
        public async Task CreateProduct(Order orders) //Om man vill kan man här konvertera objektet här
        {
            await _orderService.CreateAsync(orders);
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
