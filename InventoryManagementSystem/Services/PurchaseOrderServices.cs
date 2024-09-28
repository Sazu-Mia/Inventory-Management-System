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
    }
}
