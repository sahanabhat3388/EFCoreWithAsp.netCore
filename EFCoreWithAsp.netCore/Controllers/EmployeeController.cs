using Microsoft.AspNetCore.Mvc;

namespace EFCoreWithAsp.netCore.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }
    }
}
