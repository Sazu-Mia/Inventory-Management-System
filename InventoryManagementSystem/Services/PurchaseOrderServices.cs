using InventoryManagementSystem.Models;
using InventoryManagementSystem.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystem.Services
{
    public class PurchaseOrderServices : IPurchaseOrderServices
    {
        private readonly ERPDbContext _context;
        public PurchaseOrderServices(ERPDbContext context)
        {
            _context = context;
        }

        public async Task<int> SavePurchaseOrder(PurchaseOrder purchaseOrder)
        {
            if (purchaseOrder.Id > 0)
            {
                _context.purchaseOrders.Update(purchaseOrder);
            }
            else
            {
                _context.purchaseOrders.Add(purchaseOrder);
            }
            await _context.SaveChangesAsync();
            return purchaseOrder.Id;
        }

        public async Task<IEnumerable<PurchaseOrder>> GetAllPurchaseOrder()
        {
            return await _context.purchaseOrders.Include(x=> x.Supplier).AsNoTracking().ToListAsync();
        }

        public async Task<int?> GetMaxPurchaseOrderId()
        {
            return await _context.purchaseOrders.MaxAsync(x => (int?)x.Id);
        }
        
        public async Task<int> SavePurchaseOrderDetail(PurchaseOrderDetail purchaseOrderDetail)
        {
            try
            {
                if(purchaseOrderDetail.Id > 0)
                {
                    _context.purchaseOrderDetails.Update(purchaseOrderDetail);
                }
                else
                {
                    _context.purchaseOrderDetails.Add(purchaseOrderDetail);
                }
                await _context.SaveChangesAsync();
                return purchaseOrderDetail.Id;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<IEnumerable<PurchaseOrderDetail>> GetAllPurchaseOrderDetail()
        {
            return await _context.purchaseOrderDetails.Include(x=> x.PurchaseOrder).Include(x=> x.Product).AsNoTracking().ToListAsync();
        }
    }
}
