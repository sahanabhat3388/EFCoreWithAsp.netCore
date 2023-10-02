using EFCoreWithAsp.netCore.Repositories;
using EFCoreWithAsp.netCore.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreWithAsp.netCore.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository _departmentRepository;
        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        public async Task<IActionResult> Index()
        {
            //Fetch the data from database
            var departments = await _departmentRepository.GetAllAsync();
            return View(departments);
        }
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(DepartmentViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return View(model); // Return to the form with validation errors
            }

            //Insert data to the database           
            await _departmentRepository.AddAsync(model);

            // Redirect to List all department page
            return RedirectToAction("Index", "Department");
        }
    }
}
