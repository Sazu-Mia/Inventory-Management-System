using DinkToPdf.Contracts;
using InventoryManagementSystem.Helpers;
using InventoryManagementSystem.Services.Interface;
using InventoryManagementSystem.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.Controllers
{
    public class ReportController : Controller
    {
        private readonly string rootPath;
        private readonly MyPDF myPDF;
        private readonly ISalesOrderServices salesOrderServices;

        public ReportController(Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment, IConverter converter, ISalesOrderServices salesOrderServices)
        {
            myPDF = new MyPDF(hostingEnvironment, converter);
            rootPath = hostingEnvironment.ContentRootPath;
            this.salesOrderServices = salesOrderServices;
        }

        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult SalesReportPDF(string? SalesOrderNo)
        {

            string scheme = Request.Scheme;
            var host = Request.Host;

            string url = scheme + "://" + host + "/Report/SalesReportView?SalesOrderNo=" + SalesOrderNo;

            string fileName;
            string status = myPDF.GeneratePDF(out fileName, url);

            if (status != "done")
            {
                return Content("<h1>Something Went Wrong</h1>");
            }

            var stream = new FileStream(rootPath + "/wwwroot/pdf/" + fileName, FileMode.Open);
            return new FileStreamResult(stream, "application/pdf");
        }

        [AllowAnonymous]
        public async Task<IActionResult> SalesReportView(string? SalesOrderNo)
        {
            var model = new CategoryVM
            {
               
                salesOrders = await salesOrderServices.GetAllSalesOrder(),

            };
            return View(model);

        }
    }
}
