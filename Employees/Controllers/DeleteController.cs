using Employees.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Employees.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class DeleteController : ControllerBase
    {
        [HttpDelete]
        [Route("delete")]
        public IActionResult Delete(ID id)
        {
            using (var db = new DataBaseContext())
            {
                var entityToDelete = db.Employee.FirstOrDefault(x => x.Pk_employee_id == id.id);
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

    }
}
