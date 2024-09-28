using InventoryManagementSystem.Models;
using InventoryManagementSystem.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystem.Services
{
    public class CustomerServices : ICustomerServices
    {
        private readonly ERPDbContext _context;
        public CustomerServices(ERPDbContext context)
        {
            _context = context;
        }

        public async Task<int> SaveCustomer(Customer customer)
        {
            if (customer.Id > 0)
            {
                _context.customers.Update(customer);
            }
            else
            {
                _context.customers.Add(customer);
            }
            await _context.SaveChangesAsync();
            return customer.Id;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomer()
        {
            return await _context.customers.AsNoTracking().ToListAsync();
        }
    }
}
