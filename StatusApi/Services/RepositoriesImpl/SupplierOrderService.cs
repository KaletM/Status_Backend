using Microsoft.EntityFrameworkCore;
using StatusApi.Services.Repositories;
using StatusERP.Domain.Models;

namespace StatusApi.Services.RepositoriesImpl
{
    public class SupplierOrderService : ISupplierOrderRepository
    {
        private readonly ApplicationDbContext _context;

        public SupplierOrderService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SupplierOrder>> GetAllAsync()
        {
            return await _context.SupplierOrders
                .Include(o => o.Supplier)
                .ToListAsync();
        }

        public async Task<SupplierOrder?> GetByIdAsync(int id)
        {
            return await _context.SupplierOrders
                .Include(o => o.Supplier)
                .FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<SupplierOrder> AddAsync(SupplierOrder order)
        {
            _context.SupplierOrders.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<SupplierOrder?> UpdateAsync(int id, SupplierOrder order)
        {
            var existing = await _context.SupplierOrders.FindAsync(id);
            if (existing == null) return null;

            existing.Id = order.Id;
            existing.SupplierId = order.SupplierId;
            existing.OrderDate = order.OrderDate;
            existing.Status = order.Status;
            existing.Total = order.Total;

            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _context.SupplierOrders.FindAsync(id);
            if (existing == null) return false;

            _context.SupplierOrders.Remove(existing);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
