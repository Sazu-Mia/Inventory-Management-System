using Microsoft.AspNetCore.Identity;

namespace InventoryManagementSystem.Models
{
	public class ApplicationUser : IdentityUser
	{
		public int? userId { get; set; }
		public string identityUserName { get; set; }
	}
}
