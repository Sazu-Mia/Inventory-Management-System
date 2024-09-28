using InventoryManagementSystem.Models;

namespace InventoryManagementSystem.Services.Interface
{
    public interface IProductServices
    {
        Task<int> SaveProduct(Product product);
        Task<IEnumerable<Product>> GetAllProduct();
        Task<Product> GetProductById(int? productId);
    }
}
