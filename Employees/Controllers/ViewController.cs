using Employees.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Employees.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class ViewController : ControllerBase
    {
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
