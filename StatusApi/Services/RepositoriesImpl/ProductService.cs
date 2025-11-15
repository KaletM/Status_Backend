using Microsoft.EntityFrameworkCore;
using StatusApi.Services.Repositories;
using StatusERP.Domain.Models;

namespace StatusApi.Services.RepositoriesImpl
{
    public class ProductService : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<Product> AddAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product?> UpdateAsync(int id, Product product)
        {
            var existing = await _context.Products.FindAsync(id);
            if (existing == null) return null;

            existing.RestaurantId  = product.RestaurantId;
            existing.Name        = product.Name;
            existing.Description = product.Description;
            existing.Price       = product.Price;
            existing.Category    = product.Category;
            existing.CurrentStock = product.CurrentStock;
            existing.MinimumStock = product.MinimumStock;
            existing.IsActive     = product.IsActive;

            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _context.Products.FindAsync(id);
            if (existing == null) return false;

            _context.Products.Remove(existing);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
