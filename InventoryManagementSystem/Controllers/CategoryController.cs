using InventoryManagementSystem.Models;
using InventoryManagementSystem.Services.Interface;
using InventoryManagementSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.Controllers
{
	public class CategoryController : Controller
	{
		private readonly ICategoryServices _categoryServices;
		public CategoryController(ICategoryServices categoryServices)
		{
			this._categoryServices = categoryServices;
		}
		public async Task<IActionResult> Index()
		{
			CategoryVM model = new CategoryVM
			{
				categories = await _categoryServices.GetAllCategory()
			};
			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Index([FromForm] CategoryVM model)
		{
			try
			{
                var data = new Category
                {
                    Id = Convert.ToInt32(model.editId),
                    CategoryName = model.CategoryName,
                    Description = model.Description
                };
                await _categoryServices.SaveCategory(data);
                return Json(true);
            }
			catch (Exception ex)
			{

				return Json(false);
			}
		}
	}
}
