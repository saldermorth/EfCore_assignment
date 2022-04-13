using assignment_Dataaccess.Models;
using assignment_Dataaccess.Models.Enities;
using assignment_Dataaccess.Models.Forms;
using Microsoft.EntityFrameworkCore;

namespace assignment_Dataaccess.Services
{
    
    public interface IOrderService
    {
        Task CreateAsync(OrderForm order);
        Task<Order> ReadAsync();
        Task<Order> ReadAsyncById(int id);
        
    }
    public class OrderService : IOrderService
    {
        private readonly SqlContext _context;

        public OrderService(SqlContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(OrderForm order)
        {
            // check if products id exits. or return.
            if (!await _context.OrderItems.AnyAsync(x => x.Id == order.Id)) 
            {// foreach (var item in await _context.Customers.ToListAsync()) Bara för att hämta från DB ?
                foreach (var cartitem in order.OrderItem)
                {
                    if (await _context.Products.AnyAsync(x => x.Id == cartitem.ProductsID))
                    {
                        var orderItemsEntity = new OrderItemsEntity
                        {
                            Id = cartitem.Id,
                            ProductId = cartitem.ProductsID,
                            Quantity = cartitem.Quantity
                        };
                        _context.OrderItems.Add(orderItemsEntity);
                        await _context.SaveChangesAsync();// fail hära pga objekt finns inte i under categorier




                        var orderEntity = new OrderEntity
                        {
                            Id = order.Id,
                            CustomerId = order.CustomerID,
                            OrderDate = order.OrderDate,
                            CartItem = (ICollection<OrderItemsEntity>)order.OrderItem
                        };

                        _context.OrderItemsEntity.Add(orderEntity);
                        await _context.SaveChangesAsync();
                    }
                    
                }



             
                /*  var customerEntity = new CustomerEntity
                    {
                        FirstName = customer.FirstName,
                        LastName = customer.LastName,
                        Email = customer.Email,
                        Address = customer.Address
                    };
                    _context.Customers.Add(customerEntity);
                    await _context.SaveChangesAsync();
                */





            }

            //if (!await _context.Orders.AnyAsync(x =>
            //x.Email == customer.Email))//Går inte in i if satsen
            //{
            //    var addressEntity = await _context.Addresses.FirstOrDefaultAsync(x => x.Id == customer.Address.Id); //TODO vad får den in .Om addressid finns använd det annars skapa
            //    if (addressEntity == null)
            //    {
            //        addressEntity = new AddressEntity
            //        {
            //            Street = customer.Address.Street,
            //            ZipCode = customer.Address.ZipCode,
            //            City = customer.Address.City,

            //        };
            //        _context.Addresses.Add(addressEntity);
            //        await _context.SaveChangesAsync();


            //        var customerEntity = new CustomerEntity
            //        {
            //            FirstName = customer.FirstName,
            //            LastName = customer.LastName,
            //            Email = customer.Email,
            //            Address = customer.Address
            //        };
            //        _context.Customers.Add(customerEntity);
            //        await _context.SaveChangesAsync();
            //    }
            //}
        }

        public Task<Order> ReadAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Order> ReadAsyncById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
