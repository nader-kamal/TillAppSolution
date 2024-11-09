using TillApp.Domain.Entities;

namespace TillApp.Application.Interfaces
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProductsAsync();
    }
}
