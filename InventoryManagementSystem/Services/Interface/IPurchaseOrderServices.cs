using InventoryManagementSystem.Models;

namespace InventoryManagementSystem.Services.Interface
{
    public interface IPurchaseOrderServices
    {
        Task<IEnumerable<PurchaseOrder>> GetAllPurchaseOrder();
        Task<int> SavePurchaseOrder(PurchaseOrder purchaseOrder);
        Task<int?> GetMaxPurchaseOrderId();
        Task<int> SavePurchaseOrderDetail(PurchaseOrderDetail purchaseOrderDetail);
        Task<IEnumerable<PurchaseOrderDetail>> GetAllPurchaseOrderDetail();
    }
}
