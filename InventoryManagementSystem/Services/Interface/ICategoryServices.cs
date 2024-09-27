using InventoryManagementSystem.Models;

namespace InventoryManagementSystem.Services.Interface
{
	public interface ICategoryServices
	{
		Task<int> SaveCategory(Category category);
		Task<IEnumerable<Category>> GetAllCategory();
	}
}
