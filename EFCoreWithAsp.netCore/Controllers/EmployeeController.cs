using EFCoreWithAsp.netCore.Models;
using EFCoreWithAsp.netCore.Repositories;
using EFCoreWithAsp.netCore.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace EFCoreWithAsp.netCore.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        //Dependency injection
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        
        //GET: Employee/Add
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var departments = await _employeeRepository.GetAllDepartments();
            ViewBag.Departments = new SelectList(departments, "DepartmentId", "Name");

            return View();
        }

        //POST: Employee/Add
        [HttpPost]
        public async  Task<IActionResult> Add(EmployeeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model); // Return to the form with validation errors
            }


            // Save the employee to the database
            await _employeeRepository.AddAsync(model);

            // Redirect to List all department page
            return RedirectToAction("Index", "Employee");
        }
    }
}
