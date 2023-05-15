using ApischoolEase.Models;
using ApischoolEase.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApischoolEase.Controllers
{
    [Route("api/[controller]")]
    public class MatriculaController : ControllerBase
    {
        IMatriculaService matriculaService;
        public MatriculaController(IMatriculaService service)
        {
            matriculaService = service;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(matriculaService.Get());
        }
        [HttpPost]
        public IActionResult Save([FromBody] Matricula matricula)
        {
            return Ok(matriculaService.Save(matricula));
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Matricula matricula)
        {
            matriculaService.Update(id, matricula);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            matriculaService.Delete(id);
            return Ok();
        }
    }
}
