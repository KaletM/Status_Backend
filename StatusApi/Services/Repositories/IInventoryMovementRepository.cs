using StatusERP.Domain.Models;

namespace StatusApi.Services.Repositories
{
    public interface IInventoryMovementRepository
    {
        Task<IEnumerable<InventoryMovement>> GetAllAsync();
        Task<InventoryMovement?> GetByIdAsync(int id);
        Task<InventoryMovement> AddAsync(InventoryMovement movement);
        Task<InventoryMovement?> UpdateAsync(int id, InventoryMovement movement);
        Task<bool> DeleteAsync(int id);
    }
}
