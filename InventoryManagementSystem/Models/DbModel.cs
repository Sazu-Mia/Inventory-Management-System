namespace InventoryManagementSystem.Models
{
	public class Category : Base
	{
		public string CategoryName { get; set; }
		public string Description { get; set; }

	}

	public class Product : Base
	{
		public string ProductName { get; set; }
		public int? StockLevel { get; set; }
		public decimal? UnitPrice { get; set; }
		public string Description { get; set; }

		public int? CategoryId { get; set; }
		public Category Category { get; set; }

	}

	public class Supplier : Base
	{
		public string SupplierName { get; set; }
		public string ContactInfo { get; set; }

	}
	public class PurchaseOrder : Base
	{
		public DateTime? OrderDate { get; set; }
		public decimal? TotalAmount { get; set; }
		public string Status { get; set; }

		public int? SupplierId { get; set; }
		public Supplier Supplier { get; set; }

	}

	public class PurchaseOrderDetail : Base
	{
		public int? Quantity { get; set; }
		public decimal? PricePerUnit { get; set; }

		public decimal? TotalPrice { get; set; }

		public int? PurchaseOrderId { get; set; }
		public PurchaseOrder PurchaseOrder { get; set; }

		public int? ProductId { get; set; }
		public Product Product { get; set; }
	}

	public class Customer : Base
	{
		public string CustomerName { get; set; }
		public string ContactInfo { get; set; }

	}
	public class SalesOrder : Base
	{
		public int SalesOrderId { get; set; }
		public DateTime OrderDate { get; set; }
		public decimal TotalAmount { get; set; }
		public string Status { get; set; }

		public int? CustomerId { get; set; }
		public Customer Customer { get; set; }

	}

	public class SalesOrderDetail : Base
	{
		public int? Quantity { get; set; }
		public decimal? PricePerUnit { get; set; }

		public decimal? TotalPrice { get; set; }

		public int? SalesOrderId { get; set; }
		public SalesOrder SalesOrder { get; set; }

		public int? ProductId { get; set; }
		public Product Product { get; set; }
	}

}
