using InventoryManagementSystem.Models;
using InventoryManagementSystem.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystem.Services
{
    public class SupplierServices : ISupplierServices
    {
        private readonly ERPDbContext _context;
        public SupplierServices(ERPDbContext context)
        {
            _context = context;
        }

        public async Task<int> SaveSupplier(Supplier supplier)
        {
            if (supplier.Id > 0)
            {
                _context.suppliers.Update(supplier);
            }
            else
            {
                _context.suppliers.Add(supplier);
            }
            await _context.SaveChangesAsync();
            return supplier.Id;
        }

        public async Task<IEnumerable<Supplier>> GetAllSupplier()
        {
            return await _context.suppliers.AsNoTracking().ToListAsync();
        }
    }
}
