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
        public DateTime? OrderDate { get; set; }
        public decimal? TotalAmount { get; set; }
        public string Status { get; set; }

        public int? SupplierId { get; set; }
        public int? productId { get; set; }
        public string? PurchaseOrderNo { get; set; }
        public string? SalesOrderNo { get; set; }

        public int? Quantity { get; set; }
        public decimal? PricePerUnit { get; set; }

        public decimal? TotalPrice { get; set; }

        public int? PurchaseOrderId { get; set; }
        public int? SalesOrderId { get; set; }

        public int? ProductId { get; set; }

        public int? CustomerId { get; set; }
        public IEnumerable<Category> categories { get; set; }
		public IEnumerable<Product> products { get; set; }
		public IEnumerable<Supplier> suppliers { get; set; }
		public IEnumerable<Customer> customers { get; set; }
		public IEnumerable<PurchaseOrder> purchaseOrders { get; set; }
		public IEnumerable<PurchaseOrderDetail> orderDetails { get; set; }
        public IEnumerable<SalesOrder> salesOrders { get; set; }
        public IEnumerable<SalesOrderDetail> salesOrderDetails { get; set; }
        public IEnumerable<SalesOrderVM> salesOrderVMs { get; set; }
	}

    public class SalesOrderVM
    {
       public string SalesOrderNo { get; set; }
       public string SupplierName { get; set; }
       public string PurchaseOrderNo { get; set; }
       public string CustomerName { get; set; }
       public string ProductName { get; set; }
       public DateTime?  OrderDate { get; set; }
       public int? Quantity { get; set; }
       public decimal?  PricePerUnit { get; set; }
        public decimal? TotalPrice { get; set; }
    }
}
