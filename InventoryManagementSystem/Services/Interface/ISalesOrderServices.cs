using InventoryManagementSystem.Models;
using InventoryManagementSystem.ViewModels;

namespace InventoryManagementSystem.Services.Interface
{
    public interface ISalesOrderServices
    {
        Task<int> SaveSalesOrder(SalesOrder salesOrder);
        Task<IEnumerable<SalesOrder>> GetAllSalesOrder();
        Task<int?> GetMaxSalesOrderId();
        Task<int> SaveSalesOrderDetail(SalesOrderDetail salesOrderDetail);
        Task<IEnumerable<SalesOrderDetail>> GetAllSalesOrderDetail();
        Task<IEnumerable<SalesOrderVM>> GetSalesDetailByDate(DateTime? fromDate, DateTime? toDate);
        Task<IEnumerable<SalesOrderVM>> GetPurchaseDetailByDate(DateTime? fromDate, DateTime? toDate);
    }
}
