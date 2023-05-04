using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApischoolEase.Controllers
{
    [Route("api/[controller]")]
    public class CreateDataBaseController: ControllerBase
    {
        SchoolEaseContext dbcontext;
        public CreateDataBaseController(SchoolEaseContext context)
        {
            dbcontext = context;
        }

        [HttpGet]
        [Route("createdb")]
        public IActionResult CreateDatabase()
        {
            dbcontext.Database.EnsureCreated();
            return Ok();
        }
        [HttpGet]
        [Route("updatedb")]
        public IActionResult UpdateDatabase()
        {
            dbcontext.Database.MigrateAsync();
            return Ok();
        }
        [HttpGet]
        [Route("deletedb")]
        public IActionResult DeleteDataBase()
        {
            dbcontext.Database.EnsureDeleted();
            return Ok();
        }
    }
}
