using Microsoft.EntityFrameworkCore;
using OrderService.Model;

namespace OrderService.Service
{
    public interface IOrderService 
    {
        Task<IEnumerable<Order>> GetAllOrderAsync();
        Task<Order?> GetOrderByIdAsync(int id);
        Task<IEnumerable<Order>> GetOrderByCustomerIdAsync(string customerId);
        Task<Order> PlaceOrderAsync(Order order);
        Task UpdateOrderAsync(int id, string status);
        Task CancelOrderAsync(int id);
    }
}
