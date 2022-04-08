using assignment_Dataaccess.Models;

namespace assignment_Dataaccess.Services
{
    public interface IOrderService
    {
        Task CreateAsync(Order product);
        Task<Order> ReadAsync();
        Task<Order> ReadAsyncById(int id);
        
    }
    public class OrderService : IOrderService
    {
        public Task CreateAsync(Order product)
        {
            throw new NotImplementedException();
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
