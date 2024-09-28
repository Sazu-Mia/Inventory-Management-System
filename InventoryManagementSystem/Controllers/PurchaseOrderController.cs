using InventoryManagementSystem.Models;
using InventoryManagementSystem.Services;
using InventoryManagementSystem.Services.Interface;
using InventoryManagementSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.Controllers
{
    public class PurchaseOrderController : Controller
    {
        private readonly IPurchaseOrderServices purchaseOrderServices;
        private readonly IProductServices productServices;
        private readonly ISupplierServices supplierServices;
        public PurchaseOrderController(IPurchaseOrderServices purchaseOrderServices, IProductServices productServices, ISupplierServices supplierServices)
        {
            this.purchaseOrderServices = purchaseOrderServices;
            this.productServices = productServices;
            this.supplierServices = supplierServices;
        }
        public async Task<IActionResult> Index()
        {
            CategoryVM model = new CategoryVM
            {
                purchaseOrders = await purchaseOrderServices.GetAllPurchaseOrder(),
                suppliers = await supplierServices.GetAllSupplier(),
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index([FromForm] CategoryVM model)
        {
            try
            {
                var data = new PurchaseOrder
                {
                    Id = Convert.ToInt32(model.editId),
                    OrderDate = model.OrderDate,
                    TotalAmount = model.TotalAmount,
                    SupplierId = model.SupplierId
                    
                };
                await purchaseOrderServices.SavePurchaseOrder(data);

                return Json(true);
            }
            catch (Exception ex)
            {

                return Json(false);
            }
        }
    }
}
