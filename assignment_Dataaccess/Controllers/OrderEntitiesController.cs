#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using assignment_Dataaccess.Models;
using assignment_Dataaccess.Models.Enities;
using assignment_Dataaccess.Services;
using assignment_Dataaccess.Models.Forms;

namespace assignment_Dataaccess.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderEntitiesController : ControllerBase
    {
        private readonly OrderEntityService _orderEntityService;

        public OrderEntitiesController(SqlContext context)
        {
           
        }
        // POST: api/OrderEntities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrderEntity>> PostOrderEntity(OrderForm orderEntity)
        {
            var entity = _orderEntityService.CreateAsync(orderEntity);
           

            return CreatedAtAction("GetOrderEntity", new { id = orderEntity.Id }, orderEntity);
        }



        //// GET: api/OrderEntities
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<OrderEntity>>> GetOrders()
        //{
        //    return await _context.Orders.ToListAsync();
        //}

        //// GET: api/OrderEntities/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<OrderEntity>> GetOrderEntity(int id)
        //{
        //    var orderEntity = await _context.Orders.FindAsync(id);

        //    if (orderEntity == null)
        //    {
        //        return NotFound();
        //    }

        //    return orderEntity;
        //}

        //// PUT: api/OrderEntities/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutOrderEntity(int id, OrderEntity orderEntity)
        //{
        //    if (id != orderEntity.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(orderEntity).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!OrderEntityExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}



        //// DELETE: api/OrderEntities/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteOrderEntity(int id)
        //{
        //    var orderEntity = await _context.Orders.FindAsync(id);
        //    if (orderEntity == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Orders.Remove(orderEntity);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool OrderEntityExists(int id)
        //{
        //    return _context.Orders.Any(e => e.Id == id);
        //}
    }
}
