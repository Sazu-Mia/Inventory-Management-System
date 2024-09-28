using InventoryManagementSystem.Models;

namespace InventoryManagementSystem.Services.Interface
{
    public interface IPurchaseOrderServices
    {
        Task<IEnumerable<PurchaseOrder>> GetAllPurchaseOrder();
        Task<int> SavePurchaseOrder(PurchaseOrder purchaseOrder);
    }
}
