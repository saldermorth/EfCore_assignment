﻿using assignment_Dataaccess.Filters;
using assignment_Dataaccess.Models;
using assignment_Dataaccess.Models.Enities;
using assignment_Dataaccess.Models.Forms;
using assignment_Dataaccess.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace assignment_Dataaccess.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [UseApiKey]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        #region Create
        [HttpPost]
        public async Task<ActionResult> CreateProduct(OrderForm orders) //Om man vill kan man här konvertera objektet här
        {

            await _orderService.CreateAsyncTwo(orders);

            return Ok();
            //try
            //{
                
            //}
            //catch (Exception)
            //{
            //    return BadRequest();
            //}
        }

        #endregion
        #region Read

        [HttpGet]
        //[UseAdminKey]
        public async Task<IActionResult> GetAllCategories()
        {
            return new OkObjectResult(await _orderService.ReadAsync());
        }
        #endregion
        #region Update
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, OrderUpdateEntity orders)
        {
            var item = await _orderService.UpdateAsyncById(id, orders);
            if (!item)
            {
                return NotFound();
            }
            return Ok($"Order with id :{id} Updated. ");
        }
        #endregion
        #region Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var item = await _orderService.Delete(id);
            if (!item)
            {
                return NotFound();
            }
            return Ok($"Order with id: {id} deleted.");
        }

        #endregion
    }
}
