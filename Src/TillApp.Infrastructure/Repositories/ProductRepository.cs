using Microsoft.EntityFrameworkCore;
using TillApp.Application.Interfaces;
using TillApp.Domain.Entities;
using TillApp.Infrastructure.Data;

namespace TillApp.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }
    }
}
