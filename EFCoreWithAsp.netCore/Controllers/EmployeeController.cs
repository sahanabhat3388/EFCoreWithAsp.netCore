using EFCoreWithAsp.netCore.Models;
using EFCoreWithAsp.netCore.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

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
            List<Department> departments = new List<Department>
            {
                new Department { DepartmentId=1, Name="IT" },
                new Department { DepartmentId = 2, Name = "HR" }
            };

            ViewBag.Departments = new SelectList(departments, "DepartmentId", "Name");

            return View();
        }

        //POST: Employee/Add
        [HttpPost]
        public IActionResult Add(EmployeeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model); // Return to the form with validation errors
            }

            //Insert data to the database           
            return View(model);
        }
    }
}
