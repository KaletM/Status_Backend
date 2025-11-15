using StatusERP.Domain.Models;

namespace StatusApi.Services.Repositories
{
    public interface ISupplierRepository
    {
        Task<IEnumerable<Supplier>> GetAllAsync();
        Task<Supplier?> GetByIdAsync(int id);
        Task<Supplier> AddAsync(Supplier supplier);
        Task<Supplier?> UpdateAsync(int id, Supplier supplier);
        Task<bool> DeleteAsync(int id);
    }
}
