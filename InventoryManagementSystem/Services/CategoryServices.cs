using InventoryManagementSystem.Models;
using InventoryManagementSystem.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystem.Services
{
	public class CategoryServices : ICategoryServices
	{
		private readonly ERPDbContext _context;
		public CategoryServices(ERPDbContext context)
		{
			_context = context;
		}

		public async Task<int> SaveCategory(Category category)
		{
			if(category.Id > 0)
			{
				_context.categories.Update(category);
			}
			else
			{
				_context.categories.Add(category);
			}
			await _context.SaveChangesAsync();
			return category.Id;
		}

		public async Task<IEnumerable<Category>> GetAllCategory()
		{
			return await _context.categories.AsNoTracking().ToListAsync();
		}
	}
}
