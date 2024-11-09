using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using TillApp.Shared.Entities;

namespace TillApp.Shared.Services
{
    public class OrderService
    {
        private readonly HttpClient _httpClient;

        public OrderService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// Creates an order along with its items in a single request.
        /// </summary>
        /// <param name="order">OrderDto containing order details and items.</param>
        /// <returns>The created OrderDto with updated information from the server.</returns>
        public async Task<OrderDto> CreateOrderWithItemsAsync(OrderDto order)
        {
            var response = await _httpClient.PostAsJsonAsync("api/orders", order);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<OrderDto>();
        }

        /// <summary>
        /// Retrieves all unpaid orders.
        /// </summary>
        /// <returns>List of unpaid orders.</returns>
        public async Task<List<OrderDto>> GetUnpaidOrdersAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<OrderDto>>("api/orders/unpaid");
        }

        /// <summary>
        /// Marks a specific order as paid by its ID.
        /// </summary>
        /// <param name="orderId">ID of the order to mark as paid.</param>
        public async Task MarkOrderAsPaidAsync(int orderId)
        {
            var response = await _httpClient.PutAsync($"api/orders/{orderId}/markAsPaid", null);
            response.EnsureSuccessStatusCode();
        }

        /// <summary>
        /// Retrieves the list of products.
        /// </summary>
        /// <returns>List of available products.</returns>
        public async Task<List<ProductDto>> GetProductsAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<ProductDto>>("api/products");
            }
            catch (Exception ex)
            {
                return new List<ProductDto>();
                throw;
            }
            
        }
    }
}
