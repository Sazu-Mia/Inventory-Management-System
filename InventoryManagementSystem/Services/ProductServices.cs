using InventoryManagementSystem.Models;
using InventoryManagementSystem.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystem.Services
{
    public class ProductServices : IProductServices
    {
        private readonly ERPDbContext _context;
        public ProductServices(ERPDbContext context)
        {
            _context = context;
        }

        public async Task<int> SaveProduct(Product product)
        {
            if (product.Id > 0)
            {
                _context.products.Update(product);
            }
            else
            {
                _context.products.Add(product);
            }
            await _context.SaveChangesAsync();
            return product.Id;
        }

        public async Task<IEnumerable<Product>> GetAllProduct()
        {
            return await _context.products.Include(x=> x.Category).AsNoTracking().ToListAsync();
        }

        public async Task<Product> GetProductById(int? productId)
        {
            var product = await _context.products
                .Include(x => x.Category)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == productId);

            if (product == null)
            {
                throw new Exception($"Product with Id {productId} not found.");
            }

            return product;
        }

    }
}
