using EFCoreWithAsp.netCore.Models;
using System.ComponentModel.DataAnnotations;

namespace EFCoreWithAsp.netCore.ViewModels
{
    public class DepartmentViewModel
    {
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "Department name is required.")]
        public string Name { get; set; }
    }
}
