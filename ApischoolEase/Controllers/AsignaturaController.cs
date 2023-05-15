using ApischoolEase.Models;
using ApischoolEase.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApischoolEase.Controllers
{
    [Route("api/[controller]")]
    public class AsignaturaController : ControllerBase
    {
        IAsignaturaService asignaturaService;
        public AsignaturaController(IAsignaturaService service)
        {
            asignaturaService = service;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(asignaturaService.Get());
        }
        [HttpPost]
        public IActionResult Post([FromBody] Asignatura asignatura)
        {
            asignaturaService.Save(asignatura);
            return Ok();
        }
        [HttpPut("{id}")]  
        public IActionResult Put(int id, [FromBody] Asignatura asignatura)
        {
            asignaturaService.Update(id, asignatura);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            asignaturaService.Delete(id);
            return Ok();
        }

    }
}
