using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models
{
    public class Department
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string DepartmentName { get; set; }
    }
}
