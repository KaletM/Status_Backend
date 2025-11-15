using StatusERP.Domain.Models;

namespace StatusApi.Services.Repositories
{
    public interface ISupplierOrderDetailRepository
    {
        Task<IEnumerable<SupplierOrderDetail>> GetAllAsync();
        Task<SupplierOrderDetail?> GetByIdAsync(int id);
        Task<SupplierOrderDetail> AddAsync(SupplierOrderDetail detail);
        Task<SupplierOrderDetail?> UpdateAsync(int id, SupplierOrderDetail detail);
        Task<bool> DeleteAsync(int id);
    }
}
