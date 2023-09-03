using EFCoreWithAsp.netCore.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EFCoreWithAsp.netCore.ViewModels
{
    public class EmployeeViewModel
    {
        public Employee Employee { get; set; }

    }
}
