using EFCoreWithAsp.netCore.Models;
using EFCoreWithAsp.netCore.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
        public IActionResult Add(EmployeeViewModel model)
        {
            return View();
        }
    }
}
