using InventoryManagementSystem.Models;
using InventoryManagementSystem.Services.Interface;
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
    }
}
