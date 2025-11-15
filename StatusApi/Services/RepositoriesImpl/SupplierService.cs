using Microsoft.EntityFrameworkCore;
using StatusApi.Services.Repositories;
using StatusERP.Domain.Models;

namespace StatusApi.Services.RepositoriesImpl
{
    public class SupplierService : ISupplierRepository
    {
        private readonly ApplicationDbContext _context;

        public SupplierService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Supplier>> GetAllAsync()
        {
            return await _context.Suppliers.ToListAsync();
        }

        public async Task<Supplier?> GetByIdAsync(int id)
        {
            return await _context.Suppliers.FindAsync(id);
        }

        public async Task<Supplier> AddAsync(Supplier supplier)
        {
            _context.Suppliers.Add(supplier);
            await _context.SaveChangesAsync();
            return supplier;
        }

        public async Task<Supplier?> UpdateAsync(int id, Supplier supplier)
        {
            var existing = await _context.Suppliers.FindAsync(id);
            if (existing == null) return null;

            existing.Id = supplier.Id;
            existing.Name = supplier.Name;
            existing.Phone = supplier.Phone;
            existing.Email = supplier.Email;

            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _context.Suppliers.FindAsync(id);
            if (existing == null) return false;

            _context.Suppliers.Remove(existing);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
