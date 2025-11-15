using Microsoft.EntityFrameworkCore;
using StatusApi.Services.Repositories;
using StatusERP.Domain.Models;

namespace StatusApi.Services.RepositoriesImpl
{
    public class SupplierOrderDetailService : ISupplierOrderDetailRepository
    {
        private readonly ApplicationDbContext _context;

        public SupplierOrderDetailService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SupplierOrderDetail>> GetAllAsync()
        {
            return await _context.SupplierOrderDetails
                .Include(d => d.SupplierOrderId)
                .Include(d => d.ProductId)
                .ToListAsync();
        }

        public async Task<SupplierOrderDetail?> GetByIdAsync(int id)
        {
            return await _context.SupplierOrderDetails
                .Include(d => d.SupplierOrderId)
                .Include(d => d.ProductId)
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<SupplierOrderDetail> AddAsync(SupplierOrderDetail detail)
        {
            _context.SupplierOrderDetails.Add(detail);
            await _context.SaveChangesAsync();
            return detail;
        }

        public async Task<SupplierOrderDetail?> UpdateAsync(int id, SupplierOrderDetail detail)
        {
            var existing = await _context.SupplierOrderDetails.FindAsync(id);
            if (existing == null) return null;

            existing.SupplierOrderId = detail.SupplierOrderId;
            existing.ProductId = detail.ProductId;
            existing.Quantity = detail.Quantity;
            existing.UnitPrice = detail.UnitPrice;
            existing.Subtotal = detail.Subtotal;

            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _context.SupplierOrderDetails.FindAsync(id);
            if (existing == null) return false;

            _context.SupplierOrderDetails.Remove(existing);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
