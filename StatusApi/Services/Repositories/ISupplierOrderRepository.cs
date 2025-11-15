using StatusERP.Domain.Models;

namespace StatusApi.Services.Repositories
{
    public interface ISupplierOrderRepository
    {
        Task<IEnumerable<SupplierOrder>> GetAllAsync();
        Task<SupplierOrder?> GetByIdAsync(int id);
        Task<SupplierOrder> AddAsync(SupplierOrder order);
        Task<SupplierOrder?> UpdateAsync(int id, SupplierOrder order);
        Task<bool> DeleteAsync(int id);
    }
}
