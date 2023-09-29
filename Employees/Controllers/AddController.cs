using Employees.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employees.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class AddController : ControllerBase
    {
        [HttpPost]
        [Route("add")]
        public IActionResult Add(People employee)
        {
            using (var db = new DataBaseContext())
            {

                var AddInTable = new Employee
                {
                    ManagerId = employee.ManagerId,
                    Name = employee.Name,
                    Surname = employee.Surname,
                    Patronymic = employee.Patronymic,
                    Birthday = employee.Birthday,
                    Education = employee.Education,
                    Position = employee.Position,
                    Salary = employee.Salary,
                    Department_id = employee.Department_id,

                };
                db.Employee.Add(AddInTable);
                db.SaveChanges();

                return Ok();

            }


        }
    }
}
