using assignment_Dataaccess.Models;
using assignment_Dataaccess.Models.Enities;
using assignment_Dataaccess.Models.Forms;
using Microsoft.EntityFrameworkCore;

namespace assignment_Dataaccess.Services
{
    //Git check
    public interface IOrderEntityService
    {
        Task<bool> CreateAsync(OrderForm order);
   
        
    }
    public class OrderEntityService : IOrderEntityService
    {
        private readonly SqlContext _sqlcontext;

        public OrderEntityService(SqlContext sqlcontext)
        {
            _sqlcontext = sqlcontext;
        }

        public async Task<bool> CreateAsync(OrderForm order)
        {


            return true;



           // if (!await _sqlcontext.Customers.AnyAsync(x =>
           //x.Email == customer.Email))//Går inte in i if satsen
           // {
           //     var addressEntity = await _sqlcontext.Addresses.FirstOrDefaultAsync(x => x.Id == customer.Address.Id); //TODO vad får den in .Om addressid finns använd det annars skapa
           //     if (addressEntity == null)
           //     {
           //         addressEntity = new AddressEntity
           //         {
           //             Street = customer.Address.Street,
           //             ZipCode = customer.Address.ZipCode,
           //             City = customer.Address.City,

           //         };
           //         _sqlcontext.Addresses.Add(addressEntity);
           //         await _sqlcontext.SaveChangesAsync();


           //         var customerEntity = new CustomerEntity
           //         {
           //             FirstName = customer.FirstName,
           //             LastName = customer.LastName,
           //             Email = customer.Email,
           //             Address = customer.Address
           //         };
           //         _sqlcontext.Customers.Add(customerEntity);
           //         await _sqlcontext.SaveChangesAsync();
                
            




            //____________________________________________________


            //_sqlcontext.Orders.Add(order);
            //await _sqlcontext.SaveChangesAsync();

            //return CreatedAtAction("GetOrderEntity", new { id = orderEntity.Id }, orderEntity);
            //throw new NotImplementedException();
        }
    }
}
