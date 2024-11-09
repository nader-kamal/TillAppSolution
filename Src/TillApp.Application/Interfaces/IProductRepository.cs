using TillApp.Domain.Entities;

namespace TillApp.Application.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllProductsAsync();
    }
}
