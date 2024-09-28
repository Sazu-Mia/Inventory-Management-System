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
        public string SupplierName { get; set; }
        public string ContactInfo { get; set; }
        public string CustomerName { get; set; }
        public IEnumerable<Category> categories { get; set; }
		public IEnumerable<Product> products { get; set; }
		public IEnumerable<Supplier> suppliers { get; set; }
		public IEnumerable<Customer> customers { get; set; }
	}
}
