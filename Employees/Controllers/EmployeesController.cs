using Employees.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Employees.Controllers
{
    [Route("employee")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        [HttpPost]
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
                    DepartmentId = employee.DepartmentId,
                };
                db.Employee.Add(AddInTable);
                db.SaveChanges();
                return Ok();
            }
        }

        [HttpPatch]
        public IActionResult Change(int id, bool changeManagerId, People peoplechange)
        {
            using (var db = new DataBaseContext())
            {
                var employeeToUpdate = db.Employee.Find(id);

                if (peoplechange.ManagerId != null)
                {
                    var personsToUpdate = db.Employee.Where(x => x.ManagerId == employeeToUpdate.Id).ToList();
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

                db.SaveChanges();
                return Ok();
            }
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            using (var db = new DataBaseContext())
            {
                var entityToDelete = db.Employee.FirstOrDefault(x => x.Id == id);
                if (entityToDelete.ManagerId == 0)
                {
                    var personsToUpdate = db.Employee.Where(x => x.ManagerId == entityToDelete.Id).ToList();
                    foreach (var item in personsToUpdate)
                    {
                        item.ManagerId = null;
                    }
                }
                db.Employee.Remove(entityToDelete);
                db.SaveChanges();
                return Ok();
            }
        }

        [HttpGet]
        public IActionResult View(People find)
        {
            using (var db = new DataBaseContext())
            {
                var query = db.Employee.AsQueryable();

                if (find.Name != null)
                    query = query.Where(x => x.Name == find.Name);

                if (find.Surname != null)
                    query = query.Where(x => x.Surname == find.Surname);

                if (find.Patronymic != null)
                    query = query.Where(x => x.Patronymic == find.Patronymic);

                if (find.Birthday.HasValue)
                    query = query.Where(x => x.Birthday == find.Birthday);

                if (find.Education != null)
                    query = query.Where(x => x.Education == find.Education);

                if (find.Position != null)
                    query = query.Where(x => x.Position == find.Position);

                if (find.Salary.HasValue)
                    query = query.Where(x => x.Salary == find.Salary);

                var result = query.ToList();
                return Ok(result);
            }
        }
    }
}
