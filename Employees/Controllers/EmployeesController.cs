using Employees.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Employees.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
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

        [HttpDelete]
        [Route("delete")]
        public IActionResult Delete(int id)
        {
            using (var db = new DataBaseContext())
            {
                var entityToDelete = db.Employee.FirstOrDefault(x => x.Pk_employee_id == id);
                if (entityToDelete.ManagerId == 0)
                {
                    var personsToUpdate = db.Employee.Where(x => x.ManagerId == entityToDelete.Pk_employee_id).ToList();
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

        [HttpPost]
        [Route("view")]
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
