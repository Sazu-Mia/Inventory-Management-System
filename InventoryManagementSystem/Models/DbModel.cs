using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace InventoryManagementSystem.Models
{
	public class Category
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? CategoryName { get; set; }
		public string? Description { get; set; }

	}

	public class Product
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? ProductName { get; set; }
		public int? StockLevel { get; set; }
		public decimal? UnitPrice { get; set; }
		public string? Description { get; set; }

		public int? CategoryId { get; set; }
		public Category? Category { get; set; }

	}

	public class Supplier
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? SupplierName { get; set; }
		public string? ContactInfo { get; set; }

	}
	public class PurchaseOrder 
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime? OrderDate { get; set; }
		public decimal? TotalAmount { get; set; }
		public int? Status { get; set; }

		public int? SupplierId { get; set; }
		public Supplier? Supplier { get; set; }

    }

	public class PurchaseOrderDetail
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? Quantity { get; set; }
		public decimal? PricePerUnit { get; set; }

		public decimal? TotalPrice { get; set; }

		public int? PurchaseOrderId { get; set; }
		public PurchaseOrder? PurchaseOrder { get; set; }

		public int? ProductId { get; set; }
		public Product? Product { get; set; }
	}

	public class Customer 
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? CustomerName { get; set; }
		public string? ContactInfo { get; set; }

	}
	public class SalesOrder 
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
		public DateTime? OrderDate { get; set; }
		public decimal? TotalAmount { get; set; }
		public int? Status { get; set; }

		public int? CustomerId { get; set; }
		public Customer? Customer { get; set; }

	}

	public class SalesOrderDetail 
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? Quantity { get; set; }
		public decimal? PricePerUnit { get; set; }

		public decimal? TotalPrice { get; set; }

		public int? SalesOrderId { get; set; }
		public SalesOrder? SalesOrder { get; set; }

		public int? ProductId { get; set; }
		public Product? Product { get; set; }
	}

}
