using InventoryManagementSystem.Models;
using InventoryManagementSystem.Services;
using InventoryManagementSystem.Services.Interface;
using InventoryManagementSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductServices productServices;
        private readonly ICategoryServices categoryServices;
        public ProductController(IProductServices productServices, ICategoryServices categoryServices)
        {
            this.productServices = productServices;
            this.categoryServices = categoryServices;
        }
        public async Task<IActionResult> Index()
        {
            CategoryVM model = new CategoryVM
            {
                products = await productServices.GetAllProduct(),
                categories = await categoryServices.GetAllCategory()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index([FromForm] CategoryVM model)
        {
            try
            {
                var data = new Product
                {
                    Id = Convert.ToInt32(model.editId),
                    CategoryId = model.CategoryId,
                    StockLevel = model.StockLevel,
                    ProductName = model.ProductName,
                    UnitPrice = model.UnitPrice,
                    Description = model.Description
                };
                await productServices.SaveProduct(data);
                return Json(true);
            }
            catch (Exception ex)
            {

                return Json(false);
            }
        }
    }
}
