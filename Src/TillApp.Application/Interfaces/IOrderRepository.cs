﻿using TillApp.Domain.Entities;

namespace TillApp.Application.Interfaces
{
    public interface IOrderRepository
    {
        Task<Order> CreateOrderAsync(Order order);

        Task<Order> CreateOrderWithItemsAsync(Order order);

        Task<IEnumerable<Order>> GetUnpaidOrdersAsync();

        Task MarkOrderAsPaidAsync(int orderId);
    }
}