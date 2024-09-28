using InventoryManagementSystem.Models;
using InventoryManagementSystem.Services;
using InventoryManagementSystem.Services.Interface;
using InventoryManagementSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerServices customerServices;
        public CustomerController(ICustomerServices customerServices)
        {
            this.customerServices = customerServices;
        }
        public async Task<IActionResult> Index()
        {
            CategoryVM model = new CategoryVM
            {
                customers = await customerServices.GetAllCustomer(),
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index([FromForm] CategoryVM model)
        {
            try
            {
                var data = new Customer
                {
                    Id = Convert.ToInt32(model.editId),
                    CustomerName = model.CustomerName,
                    ContactInfo = model.ContactInfo
                };
                await customerServices.SaveCustomer(data);
                return Json(true);
            }
            catch (Exception ex)
            {

                return Json(false);
            }
        }
    }
}
