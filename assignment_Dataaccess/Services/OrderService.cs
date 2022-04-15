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
        //Task<bool> UpdateAsyncById(int id, List<CartItemUpdate> orderForm);
        
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
            var orderList = new List<OrderItemsEntity>();
            /*
             Här tar jag in en OrderForm ifrån användaren Som har:
            Id
            CustomerId
            ICollection<OrderItem> = Id, ProductID och Quantity.
            DateTime             
             */

          
            if (!await _sqlcontext.OrderItems.AnyAsync(x => x.Id == order.Id)) // check if products id exits. or return.
            {
                foreach (var cartitem in order.OrderItem) // För varje cartItem Gör följande.
                {
                    if (!await _sqlcontext.Products.AnyAsync(x => x.Id == cartitem.Id))// om produkten finns skapa en order
                    {
                        /*Jag måste skicka in en OrderItemsEntity och en OrdertEntity i DB därför behöver jag omvandla hära
                         * OrderItemEntity. Som har:
                         * Id
                         * 
                         * 
                         */

                        var orderItemsEntity = new OrderItemsEntity
                        {//ProductsId
                                                                      
                            //Quantity = cartitem.Quantity                            
                        };
                        //


                        orderList.Add(orderItemsEntity); // Add to the list of items in order
                        _sqlcontext.OrderItems.Add(orderItemsEntity);//Products är null
                        await _sqlcontext.SaveChangesAsync();// fail hära pga objekt finns inte i under categorier
                                                             //sparar inte i databasen nu


                        // TODO enter Custermer ID here
                        //var orderEntity = new OrderEntity
                        //{
                        //    Id = order.Id,
                        //    OrderDate = order.OrderDate,
                        //    CartItem = orderList
                        //};

                        //_sqlcontext.Orders.Add(orderEntity);
                        //await _sqlcontext.SaveChangesAsync();
                    }
                    
                }
            }
        }

        public async Task<List<OrderEntity>> ReadAsync() // Todo
        {
            var items = new List<OrderEntity>();

            //foreach (var item in await _sqlcontext.Orders.Include(x => x.Customers).Include(x => x.products).ToListAsync())
            //    items.Add(new OrderEntity 
            //    {
            //     Id = item.Id,
            //     CartItem  = item.CartItem,
            //     Customers = item.Customers,
            //     OrderDate  =   item.OrderDate,
            //     //products   =   item.products

            //    });

            return items;
        }

       

        public Task<Order> ReadAsyncById(int id)
        {
            throw new NotImplementedException();
        }

       

        //public Task<bool> UpdateAsyncById(int id, List<CartItemUpdate> orderform)
        //{
        //   //// var items = await _sqlcontext.Orders.Include(x => x.Customers).Include(x => x.CartItem).ToListAsync();

        //   // //var order = items.FirstOrDefault(x => x.Id == id);

        //   // bool orderUpdated = false;

        //   // if (order != null && orderform != null)
        //   // {
                
        //   //    foreach (var item in orderform)
        //   //     {
        //   //         order.CartItem.Add(new OrderItemsEntity
        //   //         { 
        //   //         Id = item.ProductID,
        //   //         Quantity = item.Quantity,
        //   //                            });
        //   //     }
        //   //     orderUpdated = true;


        //   //     _sqlcontext.Entry(order).State = EntityState.Modified;
        //   //     await _sqlcontext.SaveChangesAsync();

        //   //      List<OrderItem> newCart = new List<OrderItem>();
        //   //     foreach (var item in order.CartItem)
        //   //     {
        //   //         newCart.Add(  new OrderItem
        //   //         {
        //   //             Id = item.Id,
                       
        //   //             Quantity = item.Quantity
        //   //         });
        //   //     }


        //        //var updatedOrder = new OrderForm
        //        //{
        //        //    Id  = order.Id,
        //        //    CustomerID = order.Customers.Id,
        //        //    OrderItem = order.CartItem 
        //        //    }
        //        //};
        //        //return null;
        //    }

        //  return null;
        //}

       
    }
}
