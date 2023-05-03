using ApischoolEase.Models;
using ApischoolEase.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApischoolEase.Controllers
{
    [Route("api/[controller]")]
    public class JornadaAcademicaController : ControllerBase
    {
        IJornadaAcademicaService jornadaAcademicaService;
        public JornadaAcademicaController(IJornadaAcademicaService service)
        {
            jornadaAcademicaService = service;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(jornadaAcademicaService.Get());
        }
        [HttpPost]
        public IActionResult Post([FromBody] JornadaAcademica jornadaAcademica)
        {
            jornadaAcademicaService.Save(jornadaAcademica);
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] JornadaAcademica jornadaAcademica)
        {
            jornadaAcademicaService.Update(id, jornadaAcademica);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            jornadaAcademicaService.Delete(id);
            return Ok();
        }   
    }
}
