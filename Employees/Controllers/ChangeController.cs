using Employees.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Employees.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class ChangeController : ControllerBase
    {
        [HttpPatch]
        [Route("change")]
        public IActionResult Change(int id, bool changeManagerId, People peoplechange)
        {
            using (var db = new DataBaseContext())
            {

                var employeeToUpdate = db.Employee.Find(id);

                if (peoplechange.ManagerId != null)
                {
                    var personsToUpdate = db.Employee.Where(x => x.ManagerId == employeeToUpdate.Pk_employee_id).ToList();
                    foreach (var item in personsToUpdate)
                    {
                        item.ManagerId = null;
                    }
                }

                if (changeManagerId)
                {
                    employeeToUpdate.ManagerId = peoplechange.ManagerId;
                }

                if (employeeToUpdate.Name != peoplechange.Name && peoplechange.Name != null)
                    employeeToUpdate.Name = peoplechange.Name;

                if (employeeToUpdate.Surname != peoplechange.Surname && peoplechange.Surname != null)
                    employeeToUpdate.Surname = peoplechange.Surname;

                if (employeeToUpdate.Patronymic != peoplechange.Patronymic && peoplechange.Patronymic != null)
                    employeeToUpdate.Patronymic = peoplechange.Patronymic;

                if (employeeToUpdate.Birthday != peoplechange.Birthday && peoplechange.Birthday != null)
                    employeeToUpdate.Birthday = peoplechange.Birthday;

                if (employeeToUpdate.Education != peoplechange.Education && peoplechange.Education != null)
                    employeeToUpdate.Education = peoplechange.Education;

                if (employeeToUpdate.Position != peoplechange.Position && peoplechange.Position != null)
                    employeeToUpdate.Position = peoplechange.Position;

                if (employeeToUpdate.Salary != peoplechange.Salary && peoplechange.Salary != null)
                    employeeToUpdate.Salary = peoplechange.Salary;

                //if (employeeToUpdate.Department_id != peoplechange.Department_id && peoplechange.Department_id != null)
                //    employeeToUpdate.Department_id = peoplechange.Department_id;

                db.SaveChanges();
                return Ok();
            }
        }
    }
}
