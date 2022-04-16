using assignment_Dataaccess.Models;
using assignment_Dataaccess.Models.Enities;
using assignment_Dataaccess.Models.Forms;
using Microsoft.EntityFrameworkCore;

namespace assignment_Dataaccess.Services
{
  
    public interface IOrderEntityService
    {
        Task CreateAsync(OrderForm order);

    }
    public class OrderEntityService : IOrderEntityService
    {
        private readonly SqlContext _sqlcontext;

        public OrderEntityService(SqlContext sqlcontext)
        {
            _sqlcontext = sqlcontext;
        }

        public async Task CreateAsync(OrderForm order)
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
                    
                   // OrderId = order.Id,
                    ProductName = item.ProductName,
                    ProductPrice = item.Price,
                    Quantity    = item.Quantity

                });
            
            //------------------------------------------------------


            //__________________________________________________________________
            var orderEntity = new OrderEntity
            {
                //Id = order.Id,
                Address = $"{addressEntity.Street}, {addressEntity.City} {addressEntity.ZipCode}",
                CustomerId = customerEntity.Id,
                CustomerName = $"{customerEntity.FirstName} {customerEntity.FirstName}",
                OrderDate = order.OrderDate,
                OrderRows = orderRows       
               
            };




            _sqlcontext.Orders.Add(orderEntity);
            await _sqlcontext.SaveChangesAsync();           

           





        }
    }
}
