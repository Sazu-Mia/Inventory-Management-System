using InventoryManagementSystem.Models;

namespace InventoryManagementSystem.ViewModels
{
	public class CategoryVM
	{
		public int? editId {  get; set; }
		public string CategoryName { get; set; }
		public string Description { get; set; }
		public IEnumerable<Category> categories { get; set; }
	}
}
