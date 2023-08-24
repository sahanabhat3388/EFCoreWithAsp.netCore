﻿using EFCoreWithAsp.netCore.Data;
using EFCoreWithAsp.netCore.Models;
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
        public async Task AddAsync(Employee employee)
        {
            await _dbContext.Employees.AddAsync(employee);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int Id)
        {
            Employee employee = await _dbContext.Employees.FindAsync(Id);
            _dbContext.Employees.Remove(employee);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Employee>> GetAllAsync()
        {
            return await _dbContext.Employees.ToListAsync();
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
    }
}