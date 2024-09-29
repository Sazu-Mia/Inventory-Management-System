using InventoryManagementSystem.Models;
using InventoryManagementSystem.Services;
using InventoryManagementSystem.Services.Interface;
using InventoryManagementSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.Controllers
{
    public class SalesOrderController : Controller
    {
        private readonly ISalesOrderServices salesOrderServices;
        private readonly IProductServices productServices;
        private readonly ICustomerServices customerServices;

        public SalesOrderController(ISalesOrderServices salesOrderServices, IProductServices productServices, ICustomerServices customerServices)
        {
            this.salesOrderServices = salesOrderServices;
            this.productServices = productServices;
            this.customerServices = customerServices;
        }

        public async Task<IActionResult> Index()
        {
            CategoryVM model = new CategoryVM
            {
                salesOrders = await salesOrderServices.GetAllSalesOrder(),
                customers = await customerServices.GetAllCustomer(),
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index([FromForm] CategoryVM model)
        {
            try
            {


                var data = new SalesOrder
                {
                    Id = Convert.ToInt32(model.editId),
                    OrderDate = model.OrderDate,
                    TotalAmount = model.TotalAmount,
                    CustomerId = model.CustomerId,
                    SalesOrderNo = model.SalesOrderNo
                };
                await salesOrderServices.SaveSalesOrder(data);

                return Json(true);
            }
            catch (Exception ex)
            {

                return Json(false);
            }
        }

        public async Task<IActionResult> GetMaxSalesOrderId()
        {
            var maxId = await salesOrderServices.GetMaxSalesOrderId();
            var nextId = (maxId.HasValue ? maxId.Value + 1 : 1);
            var purchaseOrderNo = "SO" + '-' + DateTime.Now.ToString("yyyy-MM") + '-' + nextId.ToString("D2");
            return Json(purchaseOrderNo);


        }

        public async Task<IActionResult> SalesProduct()
        {
            CategoryVM model = new CategoryVM
            {
                salesOrders = await salesOrderServices.GetAllSalesOrder(),
                salesOrderDetails = await salesOrderServices.GetAllSalesOrderDetail(),
                products = await productServices.GetAllProduct(),
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SalesProduct([FromForm] CategoryVM model)
        {
            try
            {


                var data = new SalesOrderDetail
                {
                    Id = Convert.ToInt32(model.editId),
                    Quantity = model.Quantity,
                    PricePerUnit = model.PricePerUnit,
                    TotalPrice = model.Quantity * model.PricePerUnit,
                    SalesOrderId = model.SalesOrderId,
                    ProductId = model.productId
                };
                await salesOrderServices.SaveSalesOrderDetail(data);

                var product = await productServices.GetProductById(model.productId);
                product.StockLevel = product.StockLevel - model.Quantity;
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
