using EFCoreWithAsp.netCore.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreWithAsp.netCore.Controllers
{
    public class DepartmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(DepartmentViewModel model)
        {
            return View();
        }
    }
}
