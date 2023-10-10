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
        public async Task<IActionResult> Index(string searchString)
        {
            var employees = await _employeeRepository.GetAllAsync();

            if (!String.IsNullOrEmpty(searchString))
            {
                employees = employees.Where(n => n.FirstName.Contains(searchString)
                || n.LastName.Contains(searchString)).ToList();
            }

            return View(employees);
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


        //GET: Employee/Edit
        [HttpGet]
        public async  Task<IActionResult> Edit(int id)
        {
            //Fetch department details
            var departments = await _employeeRepository.GetAllDepartments();
            ViewBag.Departments = new SelectList(departments, "DepartmentId", "Name");

            //Fetch the employee details
            var employee = await _employeeRepository.GetByIdAsync(id);
            return View(employee);
        }

        //POST: Employee/Edit
        [HttpPost]
        public async Task<IActionResult> Edit(EmployeeViewModel employee)
        {

            if (!ModelState.IsValid)
            {
                return View(employee); // Return to the form with validation errors
            }
            //Update the database with modified details
            await _employeeRepository.UpdateAsync(employee);

            // Redirect to List all department page
            return RedirectToAction("Index", "Employee");
        }

        //GET: /Department/Delete
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            //Delete the data from database
            await _employeeRepository.DeleteAsync(id);
            // Redirect to List all department page
            return RedirectToAction("Index", "Employee");
        }
    }
}
