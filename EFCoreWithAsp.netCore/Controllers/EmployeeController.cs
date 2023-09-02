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

        
        [HttpPost]
        public IActionResult Add(string firstName, string lastName)
        {
            return View();
        }
    }
}
