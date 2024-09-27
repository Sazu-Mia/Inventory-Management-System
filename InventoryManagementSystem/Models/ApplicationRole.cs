using Microsoft.AspNetCore.Identity;

namespace InventoryManagementSystem.Models
{
	public class ApplicationRole : IdentityRole
	{
		public ApplicationRole() : base() { }
		public ApplicationRole(string roleName) : base(roleName)
		{
			
		}

		public string roleNature { get; set; }
	}
}
