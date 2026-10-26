using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using OrderService.Data;
using OrderService.Model;

namespace OrderService.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderDbContext _orderDbContext;

        public OrderRepository(OrderDbContext orderDbContext)
        {
            _orderDbContext = orderDbContext;
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await _orderDbContext.orders.Include(o => o.Items).ToListAsync();
        }

        public async Task<Order?> GetByIdAsync(int id)
        {
            return await _orderDbContext.orders.Include(o => o.Items).FirstOrDefaultAsync(o => o.Id == id);
            //return await _orderDbContext.orders.FindAsync(id);
        }

        public async Task<IEnumerable<Order>> GetByCustomerIdAsync(string customerId)
        {
            return await _orderDbContext.orders.Include(o => o.Items).Where(o => o.CustomerId == customerId).ToListAsync();
        }

        public async Task AddAsync(Order order)
        {
            await _orderDbContext.orders.AddAsync(order);
            await _orderDbContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(Order order)
        {
            var existingOrder = _orderDbContext.orders.Update(order);            
            await _orderDbContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var order = await _orderDbContext.orders.FindAsync(id);

            if(order != null)
            {
                _orderDbContext.orders.Remove(order);
                await _orderDbContext.SaveChangesAsync();
            }
        }
    }
}
