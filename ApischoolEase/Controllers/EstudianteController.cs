
using ApischoolEase.Models;
using ApischoolEase.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApischoolEase.Controllers
{
    [Route("api/[controller]")]
    public class EstudianteController : ControllerBase
    {
        IEstudianteService EstudianteService;
        public EstudianteController(IEstudianteService service)
        {
            EstudianteService = service;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(EstudianteService.Get());
        }
        [HttpPost]
        public IActionResult Post([FromBody] Estudiante estudiante)
        {
            EstudianteService.Save(estudiante);
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Estudiante estudiante)
        {
            EstudianteService.Update(id, estudiante);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            EstudianteService.Delete(id);
            return Ok();
        }
    }
}
