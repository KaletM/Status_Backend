using Microsoft.EntityFrameworkCore;
using StatusApi.Services.Repositories;
using StatusERP.Domain.Models;

namespace StatusApi.Services.RepositoriesImpl
{
    public class InventoryMovementService : IInventoryMovementRepository
    {
        private readonly ApplicationDbContext _context;

        public InventoryMovementService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<InventoryMovement>> GetAllAsync()
        {
            return await _context.InventoryMovements
                .Include(i => i.Product)
                .ToListAsync();
        }

        public async Task<InventoryMovement?> GetByIdAsync(int id)
        {
            return await _context.InventoryMovements
                .Include(i => i.Product)
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<InventoryMovement> AddAsync(InventoryMovement movement)
        {
            _context.InventoryMovements.Add(movement);
            await _context.SaveChangesAsync();
            return movement;
        }

        public async Task<InventoryMovement?> UpdateAsync(int id, InventoryMovement movement)
        {
            var existing = await _context.InventoryMovements.FindAsync(id);
            if (existing == null) return null;

            existing.ProductId = movement.ProductId;
            existing.Type = movement.Type;
            existing.Quantity = movement.Quantity;
            existing.Reason = movement.Reason;
            existing.Date = movement.Date;
            existing.UserId = movement.UserId;

            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _context.InventoryMovements.FindAsync(id);
            if (existing == null) return false;

            _context.InventoryMovements.Remove(existing);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
