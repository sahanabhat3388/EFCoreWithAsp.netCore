using EFCoreWithAsp.netCore.Models;

namespace EFCoreWithAsp.netCore.Repositories
{
    public interface IDepartmentRepository
    {
        Task<Department> GetByIdAsync(int id);
        Task<List<Department>> GetAllAsync();
        Task AddAsync(Department department);
        Task UpdateAsync(Department department);
        Task DeleteAsync(int Id);
    }
}
