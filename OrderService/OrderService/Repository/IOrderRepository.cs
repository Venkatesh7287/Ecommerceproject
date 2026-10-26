using Microsoft.EntityFrameworkCore;
using OrderService.Data;
using OrderService.Model;

namespace OrderService.Repository
{
    public interface IOrderRepository 
    {
        Task<IEnumerable<Order>> GetAllAsync();
        Task<Order?> GetByIdAsync(int id);
        Task<IEnumerable<Order>> GetByCustomerIdAsync(string customerId);
        Task AddAsync(Order order);
        Task UpdateAsync(Order order);
        Task DeleteAsync(int id);
    }
}
