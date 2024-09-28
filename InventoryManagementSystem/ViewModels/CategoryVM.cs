using InventoryManagementSystem.Models;

namespace InventoryManagementSystem.ViewModels
{
	public class CategoryVM
	{
		public int? editId {  get; set; }
		public string CategoryName { get; set; }
		public string Description { get; set; }
        public string ProductName { get; set; }
        public int? StockLevel { get; set; }
        public decimal? UnitPrice { get; set; }

        public int? CategoryId { get; set; }
        public IEnumerable<Category> categories { get; set; }
		public IEnumerable<Product> products { get; set; }
	}
}
