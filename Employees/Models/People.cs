using System;

namespace Employees.Models
{
    public class People
    {
        public int? ManagerId { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Patronymic { get; set; }
        public DateTime? Birthday { get; set; }
        public string? Education { get; set; }
        public string? Position { get; set; }
        public int? Salary { get; set; }
        public int? Department_id { get; set; }
    }
}
