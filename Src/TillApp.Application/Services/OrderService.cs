using System.Collections.Generic;
using System.Threading.Tasks;
using TillApp.Application.Interfaces;
using TillApp.Domain.Entities;

namespace TillApp.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Order> CreateOrderWithItemsAsync(Order order)
        {
            return await _orderRepository.CreateOrderWithItemsAsync(order);
        }

        public async Task<Order> CreateOrderAsync(Order order)
        {
            return await _orderRepository.CreateOrderAsync(order);
        }

        public async Task<IEnumerable<Order>> GetUnpaidOrdersAsync()
        {
            return await _orderRepository.GetUnpaidOrdersAsync();
        }

        public async Task MarkOrderAsPaidAsync(int orderId)
        {
            await _orderRepository.MarkOrderAsPaidAsync(orderId);
        }
    }
}
