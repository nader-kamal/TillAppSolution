using Microsoft.EntityFrameworkCore;
using TillApp.Domain.Entities;
using TillApp.Application.Interfaces;
using TillApp.Infrastructure.Data;

namespace TillApp.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _context;

        public OrderRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Order> CreateOrderAsync(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }
        public async Task<Order> CreateOrderWithItemsAsync(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }
        public async Task<IEnumerable<Order>> GetUnpaidOrdersAsync()
        {
            return await _context.Orders
                .Where(o => !o.IsPaid)
                .Include(o => o.Items)
                .ToListAsync();
        }

        public async Task MarkOrderAsPaidAsync(int orderId)
        {
            var order = await _context.Orders.FindAsync(orderId);
            if (order != null)
            {
                order.IsPaid = true;
                await _context.SaveChangesAsync();
            }
        }
    }
}
