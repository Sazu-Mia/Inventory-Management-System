using InventoryManagementSystem.Models;

namespace InventoryManagementSystem.Services.Interface
{
    public interface ICustomerServices
    {
        Task<IEnumerable<Customer>> GetAllCustomer();
        Task<int> SaveCustomer(Customer customer);
    }
}
