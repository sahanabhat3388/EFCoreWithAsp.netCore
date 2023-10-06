using EFCoreWithAsp.netCore.Models;
using EFCoreWithAsp.netCore.ViewModels;

namespace EFCoreWithAsp.netCore.Repositories
{
    public interface IDepartmentRepository
    {
        Task<DepartmentViewModel> GetByIdAsync(int id);
        Task<List<DepartmentViewModel>> GetAllAsync();
        Task AddAsync(DepartmentViewModel department);
        Task UpdateAsync(DepartmentViewModel department);
        Task DeleteAsync(int Id);
    }
}
