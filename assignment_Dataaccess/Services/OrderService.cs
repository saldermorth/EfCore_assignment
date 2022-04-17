using assignment_Dataaccess.Models;
using assignment_Dataaccess.Models.Enities;
using assignment_Dataaccess.Models.Forms;
using Microsoft.EntityFrameworkCore;

namespace assignment_Dataaccess.Services
{
    //Git check
    public interface IOrderService
    {

        Task<List<OrderForm>> ReadAsync();
        Task<bool> Delete(int id);
        Task<Order> ReadAsyncById(int id);
        Task CreateAsyncTwo(OrderForm order);
        Task<bool> UpdateAsyncById(int id, OrderUpdateEntity orderForm);

    }
    public class OrderService : IOrderService
    {
        private readonly SqlContext _sqlcontext;


        public OrderService(SqlContext context)
        {
            _sqlcontext = context;

        }

        public async Task<bool> Delete(int id)
        {
            var orderEntity = await _sqlcontext.Orders.FindAsync(id);
            if (orderEntity != null)
            {
                _sqlcontext.Orders.Remove(orderEntity);
                await _sqlcontext.SaveChangesAsync();
                return true;
            }



            return false;
        }


        public async Task CreateAsyncTwo(OrderForm order)
        {

            //Här bygger vi en OrderEntity igenom att Bygga kopplade entiteter förs och sedan bygga ihop den.


            //___________________________________________________________


            var customerEntity = await _sqlcontext.Customers.Include(x => x.Address).FirstAsync(x => x.Id == order.CustomerID);


            //___________________________________________________________________

            var addressEntity = new AddressEntity
            {
                Id = customerEntity.Address.Id,
                City = customerEntity.Address.City,
                Street = customerEntity.Address.Street,
                ZipCode = customerEntity.Address.ZipCode
            };

            //_________________________________________________________     
            //Get with ID
            var orderRows = new List<OrderItemsEntity>();  // creating OrdersItemEntity
            foreach (var item in order.OrderItem)
                orderRows.Add(new OrderItemsEntity
                {

                    //OrderId = order.Id,
                    ProductName = item.ProductName,
                    ProductPrice = item.Price,
                    Quantity = item.Quantity

                });
            

            //__________________________________________________________________ 
            var orderEntity = new OrderEntity
            {
                
                Address = $"{addressEntity.Street}, {addressEntity.City} {addressEntity.ZipCode}",
                CustomerId = customerEntity.Id,
                CustomerName = $"{customerEntity.FirstName} {customerEntity.FirstName}",
                OrderDate = order.OrderDate,
                OrderRows = orderRows

            };

            _sqlcontext.Orders.Add(orderEntity);
            await _sqlcontext.SaveChangesAsync();







        }


        public async Task<List<OrderForm>> ReadAsync() // Todo
        {
            var items = new List<OrderForm>();

            var orderrows = new List<CartItemUpdate>();

            //create list of orderlistitems

            foreach (var item in await _sqlcontext.Orders.Include(x => x.OrderRows).ToListAsync())
            {
                foreach (var iteminlist in item.OrderRows)
                {
                    orderrows.Add(new CartItemUpdate
                    {
                        Id = item.Id,
                        Price = iteminlist.ProductPrice,
                        Quantity = iteminlist.Quantity,
                        ProductName = iteminlist.ProductName,
                        ProductID = iteminlist.Id
                    });
                }
            }


            //create orderform and insert the list of orderitems



            foreach (var item in await _sqlcontext.Orders.ToListAsync())
            {
                items.Add(new OrderForm
                {
                    Id = item.Id,
                    CustomerID = item.CustomerId,
                    OrderDate = item.OrderDate,
                    OrderItem = orderrows
                });
            }


            return items;
        }



        public Task<Order> ReadAsyncById(int id)
        {
            throw new NotImplementedException();
        }



        public async Task<bool> UpdateAsyncById(int orderid, OrderUpdateEntity orderform)
        {

            /*
             * Här får vi in ett orderid och en OrderUpdateEntity med detta vill vi uppdatera en befintlig order.
             * 
             * 
             */


            var orderToUpdate = await _sqlcontext.Orders.FindAsync(orderid);
            var newListOfItems = new List<OrderItemsEntity>();
            //---------------------------------------------------
            //Updated list from user 
            foreach (var item in orderform.cartitems)
            {
                newListOfItems.Add(new OrderItemsEntity
                {
                    Id = item.Id,
                    OrderId = orderid,
                    ProductName = item.ProductName,
                    ProductPrice = item.Price,
                    Quantity = item.Quantity
                });
            }


            if (orderToUpdate != null)
            {
                orderToUpdate.OrderRows = newListOfItems;

                _sqlcontext.Entry(orderToUpdate).State = EntityState.Modified;
                await _sqlcontext.SaveChangesAsync();
                return true;         
            }
            return false;

        }


    }
}
