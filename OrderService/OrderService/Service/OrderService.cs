using Microsoft.AspNetCore.Http.HttpResults;
using OrderService.Model;
using OrderService.Repository;

namespace OrderService.Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<IEnumerable<Order>> GetAllOrderAsync()
        {
            return await _orderRepository.GetAllAsync();
        }

        public async Task<Order?> GetOrderByIdAsync(int id)
        {
            return await _orderRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Order>> GetOrderByCustomerIdAsync(string customerId)
        {
            return await _orderRepository.GetByCustomerIdAsync(customerId);
        }

        public async Task<Order> PlaceOrderAsync(Order order)
        {
            await _orderRepository.AddAsync(order);
            return order;
        }

        public async Task UpdateOrderAsync(int id , string status)
        {
            var order = await _orderRepository.GetByIdAsync(id);

            if(order != null)
            {
                order.Status = status;

                await _orderRepository.UpdateAsync(order);
            }
        }

        public async Task CancelOrderAsync(int id)
        {
            await _orderRepository.DeleteAsync(id);
        }
    }
}
