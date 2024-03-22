using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagement.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [MaxLength(30)]
        public string Name { get; set; }
        [Range(21, 100)]
        public int Age { get; set; }
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public decimal Salary { get; set; }
    }

}
