using EFCoreWithAsp.netCore.Models;
using EFCoreWithAsp.netCore.ViewModels;

namespace EFCoreWithAsp.netCore.Repositories
{
    public interface IDepartmentRepository
    {
        Task<Department> GetByIdAsync(int id);
        Task<List<Department>> GetAllAsync();
        Task AddAsync(DepartmentViewModel department);
        Task UpdateAsync(Department department);
        Task DeleteAsync(int Id);
    }
}
