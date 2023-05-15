
using ApischoolEase.Models;
using ApischoolEase.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApischoolEase.Controllers
{
    [Route("api/[controller]")]
    public class CalificacionController : ControllerBase
    {
        ICalificacionService CalifiacionService;
        public CalificacionController(ICalificacionService service)
        {
            CalifiacionService = service;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(CalifiacionService.Get());
        }
        [HttpPost]
        public IActionResult Post([FromBody] Calificacion calificacion)
        {
            CalifiacionService.Save(calificacion);
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Calificacion calificacion)
        {
            CalifiacionService.Update(id, calificacion);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            CalifiacionService.Delete(id);
            return Ok();
        }
    }
}
