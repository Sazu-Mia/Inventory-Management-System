using InventoryManagementSystem.Models;

namespace InventoryManagementSystem.Services.Interface
{
    public interface ISalesOrderServices
    {
        Task<int> SaveSalesOrder(SalesOrder salesOrder);
        Task<IEnumerable<SalesOrder>> GetAllSalesOrder();
        Task<int?> GetMaxSalesOrderId();
        Task<int> SaveSalesOrderDetail(SalesOrderDetail salesOrderDetail);
        Task<IEnumerable<SalesOrderDetail>> GetAllSalesOrderDetail();
    }
}
