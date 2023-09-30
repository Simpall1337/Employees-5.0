using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace Employees.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public int? ManagerId { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Patronymic { get; set; }
        public DateTime? Birthday { get; set; }
        public string? Education { get; set; }
        public string? Position { get; set; }
        public int? Salary { get; set; }
        public int? DepartmentId { get; set; }

        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }
    }
}
