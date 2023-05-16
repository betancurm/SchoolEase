using ApischoolEase.Models;
using ApischoolEase.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApischoolEase.Controllers
{
    [Route("api/[controller]")]
    public class AcudienteController : ControllerBase
    {
        IAcudienteService acudienteService;
        public AcudienteController(IAcudienteService service)
        {
            acudienteService = service;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(acudienteService.Get());
        }
        [HttpPost]
        public IActionResult Post([FromBody] Acudiente acudiente)
        {
            acudienteService.Save(acudiente);
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Acudiente acudiente)
        {
            acudienteService.Update(id, acudiente);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            acudienteService.Delete(id);
            return Ok();
        }
    }
}
