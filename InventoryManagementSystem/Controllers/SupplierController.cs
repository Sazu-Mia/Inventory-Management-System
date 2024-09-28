using InventoryManagementSystem.Models;
using InventoryManagementSystem.Services;
using InventoryManagementSystem.Services.Interface;
using InventoryManagementSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.Controllers
{
    public class SupplierController : Controller
    {
        private readonly ISupplierServices supplierServices;
        public SupplierController(ISupplierServices supplierServices)
        {
            this.supplierServices = supplierServices;
        }
        public async Task<IActionResult> Index()
        {
            CategoryVM model = new CategoryVM
            {
                suppliers = await supplierServices.GetAllSupplier(),
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index([FromForm] CategoryVM model)
        {
            try
            {
                var data = new Supplier
                {
                    Id = Convert.ToInt32(model.editId),
                    SupplierName = model.SupplierName,
                    ContactInfo = model.ContactInfo
                };
                await supplierServices.SaveSupplier(data);
                return Json(true);
            }
            catch (Exception ex)
            {

                return Json(false);
            }
        }
    }
}
