using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystem.Models
{
	public class ERPDbContext : IdentityDbContext<ApplicationUser>
	{


		public ERPDbContext(DbContextOptions options) : base(options)
		{

		}
		public DbSet<SalesOrderDetail> salesOrderDetails { get; set; } = default!;
		public DbSet<SalesOrder> salesOrders { get; set; } = default!;
		public DbSet<Customer> customers { get; set; } = default!;
		public DbSet<PurchaseOrderDetail> purchaseOrderDetails { get; set; } = default!;
		public DbSet<PurchaseOrder> purchaseOrders { get; set; } = default!;
		public DbSet<Supplier> suppliers { get; set; } = default!;
		public DbSet<Product> products { get; set; } = default!;
		public DbSet<Category> categories { get; set; } = default!;






	}
}
