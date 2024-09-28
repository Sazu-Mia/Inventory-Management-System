using InventoryManagementSystem.Models;

namespace InventoryManagementSystem.Services.Interface
{
    public interface ISupplierServices
    {
        Task<IEnumerable<Supplier>> GetAllSupplier();
        Task<int> SaveSupplier(Supplier supplier);
    }
}
