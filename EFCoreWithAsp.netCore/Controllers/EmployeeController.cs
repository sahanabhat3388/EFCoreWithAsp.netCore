using Microsoft.AspNetCore.Mvc;

namespace EFCoreWithAsp.netCore.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        
        //GET: Employee/Add
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        //POST: Employee/Add
        [HttpPost]
        public IActionResult Add(string firstName, string lastName)
        {
            return View();
        }
    }
}
