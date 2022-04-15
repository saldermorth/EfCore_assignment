using assignment_Dataaccess.Models;
using assignment_Dataaccess.Models.Enities;
using assignment_Dataaccess.Models.Forms;
using Microsoft.EntityFrameworkCore;

namespace assignment_Dataaccess.Services
{
    
    public interface IOrderService
    {
        Task CreateAsync(OrderForm order);
        Task<List<OrderEntity>> ReadAsync();
        Task<Order> ReadAsyncById(int id);
        Task<OrderForm> UpdateAsyncById(int id, List<CartItemUpdate> orderForm);
        
    }
    public class OrderService : IOrderService
    {
        private readonly SqlContext _sqlcontext;

        public OrderService(SqlContext context)
        {
            _sqlcontext = context;
        }

        public async Task CreateAsync(OrderForm order)
        {
            // check if products id exits. or return.
            if (!await _sqlcontext.OrderItems.AnyAsync(x => x.Id == order.Id)) 
            {// foreach (var item in await _context.Customers.ToListAsync()) Bara för att hämta från DB ?
                foreach (var cartitem in order.OrderItem)
                {
                    if (await _sqlcontext.Products.AnyAsync(x => x.Id == cartitem.ProductsID))// om produkten finns skapa en order
                    {
                        var orderItemsEntity = new OrderItemsEntity
                        {
                            
                            ProductId = cartitem.ProductsID,
                            Quantity = cartitem.Quantity,
                            
                            
                        };
                        _sqlcontext.OrderItems.Add(orderItemsEntity);//Products är null
                        await _sqlcontext.SaveChangesAsync();// fail hära pga objekt finns inte i under categorier
                        //sparar inte i databasen nu



                        var orderEntity = new OrderEntity
                        {
                            Id = order.Id,
                            CustomerId = order.CustomerID,
                            OrderDate = order.OrderDate,
                            CartItem = (ICollection<OrderItemsEntity>)order.OrderItem
                        };

                        _sqlcontext.Orders.Add(orderEntity);
                        await _sqlcontext.SaveChangesAsync();
                    }
                    
                }
            }
        }

        public async Task<List<OrderEntity>> ReadAsync() // Todo
        {
            var items = new List<OrderEntity>();

            foreach (var item in await _sqlcontext.Orders.Include(x => x.Customers).Include(x => x.products).ToListAsync())
                items.Add(new OrderEntity 
                {
                 Id = item.Id,
                 CartItem  = item.CartItem,
                 Customers = item.Customers,
                 OrderDate  =   item.OrderDate,
                 products   =   item.products

                });

            return items;
        }

       

        public Task<Order> ReadAsyncById(int id)
        {
            throw new NotImplementedException();
        }

       

        public async Task<OrderForm> UpdateAsyncById(int id, List<CartItemUpdate> orderform)
        {
            var items = await _sqlcontext.Orders.Include(x => x.Customers).Include(x => x.CartItem).ToListAsync();

            var order = items.FirstOrDefault(x => x.Id == id);


            if (order != null && orderform != null)
            {
                
               foreach (var item in orderform)
                {
                    order.CartItem.Add(new OrderItemsEntity
                    { 
                    Id = item.Product,
                    Quantity    = item.Quantity
                    });
                }


                _sqlcontext.Entry(order).State = EntityState.Modified;
                await _sqlcontext.SaveChangesAsync();

                 List<OrderItem> newCart = new List<OrderItem>();
                foreach (var item in order.CartItem)
                {
                    newCart.Add(  new OrderItem
                    {
                        Id = item.Id,
                        ProductsID = item.ProductId,
                        Quantity = item.ProductId
                    });
                }


                var updatedOrder = new OrderForm
                {
                    Id  = order.Id,
                    CustomerID = order.CustomerId,
                    OrderItem = newCart

                };
                return updatedOrder;
            }

            return null;
        }

       
    }
}
