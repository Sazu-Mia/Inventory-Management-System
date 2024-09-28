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
                    SupplierId = model.SupplierId,
                    PurchaseOrderNo = model.PurchaseOrderNo
                };
                await purchaseOrderServices.SavePurchaseOrder(data);

                return Json(true);
            }
            catch (Exception ex)
            {

                return Json(false);
            }
        }

        public async Task<IActionResult> GetMaxPurchaseOrderId()
        {
            var maxId = await purchaseOrderServices.GetMaxPurchaseOrderId();
            var nextId = (maxId.HasValue ? maxId.Value + 1 : 1); 
            var purchaseOrderNo = "PO" + '-' + DateTime.Now.ToString("yyyy-MM") + '-' + nextId.ToString("D2");
            return Json(purchaseOrderNo);


        }

        public async Task<IActionResult> PurchaseProduct()
        {
            CategoryVM model = new CategoryVM
            {
                purchaseOrders = await purchaseOrderServices.GetAllPurchaseOrder(),
                orderDetails = await purchaseOrderServices.GetAllPurchaseOrderDetail(),
                products = await productServices.GetAllProduct(),
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> PurchaseProduct([FromForm] CategoryVM model)
        {
            try
            {


                var data = new PurchaseOrderDetail
                {
                    Id = Convert.ToInt32(model.editId),
                    Quantity = model.Quantity,
                    PricePerUnit = model.PricePerUnit,
                    TotalPrice = model.Quantity * model.PricePerUnit,
                    PurchaseOrderId = model.PurchaseOrderId,
                    ProductId = model.productId
                };
                await purchaseOrderServices.SavePurchaseOrderDetail(data);

                var product = await productServices.GetProductById(model.productId);
                product.StockLevel = product.StockLevel + model.Quantity;
                await productServices.SaveProduct(product);

                return Json(true);
            }
            catch (Exception ex)
            {

                return Json(false);
            }
        }

    }
}
