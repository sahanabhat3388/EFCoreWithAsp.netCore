using EFCoreWithAsp.netCore.Data;
using EFCoreWithAsp.netCore.Models;
using EFCoreWithAsp.netCore.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace EFCoreWithAsp.netCore.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _dbContext;
        public EmployeeRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddAsync(EmployeeViewModel employee)
        {
            var newEmployee = new Employee()
            {
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                DateOfBirth = employee.DateOfBirth,
                PhoneNumber = employee.PhoneNumber,
                Gender = employee.Gender,
                Email = employee.Email,
                Address = employee.Address,
                DepartmentId = employee.DepartmentId
            };
            await _dbContext.Employees.AddAsync(newEmployee);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int Id)
        {
            Employee employee = await _dbContext.Employees.FindAsync(Id);
            _dbContext.Employees.Remove(employee);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<EmployeeViewModel>> GetAllAsync()
        {
            List<Employee> employees =  await _dbContext.Employees.ToListAsync();
            List<EmployeeViewModel> employeeViewModels = new List<EmployeeViewModel>();

            foreach (var employee in employees)
            {
                var employeeViewModel = new EmployeeViewModel
                {
                    EmployeeId = employee.EmployeeId,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    DateOfBirth = employee.DateOfBirth,
                    Gender = employee.Gender,
                    Email = employee.Email,
                    PhoneNumber = employee.PhoneNumber,
                    Address = employee.Address,
                    IsActive = employee.IsActive
                };

                employeeViewModels.Add(employeeViewModel);
            }

            return employeeViewModels;
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
            return await _dbContext.Employees.FindAsync(id);
        }

        public async Task UpdateAsync(Employee employeeUpdated)
        {
            var employee = await _dbContext.Employees.FindAsync(employeeUpdated.EmployeeId);
            employee.FirstName = employeeUpdated.FirstName;
            employee.LastName = employeeUpdated.LastName;
            employee.Email = employeeUpdated.Email;
            employee.DateOfBirth = employeeUpdated.DateOfBirth;
            employee.PhoneNumber = employeeUpdated.PhoneNumber;
            employee.Address = employeeUpdated.Address;
            employee.DepartmentId = employeeUpdated.DepartmentId;
            _dbContext.Employees.Update(employee);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Department>> GetAllDepartments()
        {
            return await _dbContext.Departments.ToListAsync();
        }
    }
}
