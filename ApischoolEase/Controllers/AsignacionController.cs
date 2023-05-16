using ApischoolEase.Models;
using ApischoolEase.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApischoolEase.Controllers
{
    [Route("api/[controller]")]

    public class AsignacionController : ControllerBase
    {
        IAsignacionService asignacionService;
        public AsignacionController(IAsignacionService service)
        {
            asignacionService = service;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(asignacionService.Get());
        }
        [HttpPost]
        public IActionResult Post([FromBody] Asignacion asignacion)
        {
            asignacionService.Save(asignacion);
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Asignacion asignacion)
        {
            asignacionService.Update(id, asignacion);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            asignacionService.Delete(id);
            return Ok();
        }
    }
}
