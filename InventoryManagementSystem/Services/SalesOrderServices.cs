using InventoryManagementSystem.Models;
using InventoryManagementSystem.Services.Interface;
using InventoryManagementSystem.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystem.Services
{
    public class SalesOrderServices : ISalesOrderServices
    {
        private readonly ERPDbContext _context;
        public SalesOrderServices(ERPDbContext context)
        {
            _context = context;
        }

        public async Task<int> SaveSalesOrder(SalesOrder salesOrder)
        {
            if (salesOrder.Id > 0)
            {
                _context.salesOrders.Update(salesOrder);
            }
            else
            {
                _context.salesOrders.Add(salesOrder);
            }
            await _context.SaveChangesAsync();
            return salesOrder.Id;
        }

        public async Task<IEnumerable<SalesOrder>> GetAllSalesOrder()
        {
            return await _context.salesOrders.Include(x => x.Customer).AsNoTracking().ToListAsync();
        }

        public async Task<int?> GetMaxSalesOrderId()
        {
            return await _context.salesOrders.MaxAsync(x => (int?)x.Id);
        }

        public async Task<int> SaveSalesOrderDetail(SalesOrderDetail salesOrderDetail)
        {
            try
            {
                if (salesOrderDetail.Id > 0)
                {
                    _context.salesOrderDetails.Update(salesOrderDetail);
                }
                else
                {
                    _context.salesOrderDetails.Add(salesOrderDetail);
                }
                await _context.SaveChangesAsync();
                return salesOrderDetail.Id;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<IEnumerable<SalesOrderDetail>> GetAllSalesOrderDetail()
        {
            return await _context.salesOrderDetails.Include(x => x.SalesOrder).Include(x => x.Product).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<SalesOrderVM>> GetSalesDetailByDate(DateTime? fromDate, DateTime? toDate)
        {
            try
            {
                var fDate = fromDate?.ToString("yyyy-MM-dd");
                var ftDate = toDate?.ToString("yyyy-MM-dd");

                var result = (from s in _context.salesOrders
                              join c in _context.customers on s.CustomerId equals c.Id
                              join sd in _context.salesOrderDetails on s.Id equals sd.SalesOrderId
                              join p in _context.products on sd.ProductId equals p.Id
                              where s.OrderDate >= Convert.ToDateTime(fDate) && s.OrderDate <= Convert.ToDateTime(ftDate)
                              select new SalesOrderVM
                              {
                                  SalesOrderNo = s.SalesOrderNo ?? "",
                                  CustomerName = c.CustomerName ?? "",
                                  ProductName = p.ProductName ?? "",
                                  OrderDate = s.OrderDate,
                                  Quantity = sd.Quantity,
                                  PricePerUnit = sd.PricePerUnit,
                                  TotalPrice = sd.TotalPrice
                              }).ToList();
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<IEnumerable<SalesOrderVM>> GetPurchaseDetailByDate(DateTime? fromDate, DateTime? toDate)
        {
            try
            {
                var fDate = fromDate?.ToString("yyyy-MM-dd");
                var ftDate = toDate?.ToString("yyyy-MM-dd");

                var result = (from s in _context.purchaseOrders
                              join c in _context.suppliers on s.SupplierId equals c.Id
                              join sd in _context.purchaseOrderDetails on s.Id equals sd.PurchaseOrderId
                              join p in _context.products on sd.ProductId equals p.Id
                              where s.OrderDate >= Convert.ToDateTime(fDate) && s.OrderDate <= Convert.ToDateTime(ftDate)
                              select new SalesOrderVM
                              {
                                  PurchaseOrderNo = s.PurchaseOrderNo ?? "",
                                  SupplierName = c.SupplierName ?? "",
                                  ProductName = p.ProductName ?? "",
                                  OrderDate = s.OrderDate,
                                  Quantity = sd.Quantity,
                                  PricePerUnit = sd.PricePerUnit,
                                  TotalPrice = sd.TotalPrice
                              }).ToList();
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
