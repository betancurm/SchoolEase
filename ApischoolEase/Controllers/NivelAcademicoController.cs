using ApischoolEase.Models;
using ApischoolEase.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApischoolEase.Controllers
{
    [Route("api/[controller]")]
    public class NivelAcademicoController : ControllerBase
    {
        INivelAcademicoService nivelAcademicoService;
        public NivelAcademicoController(INivelAcademicoService service)
        {
            nivelAcademicoService = service;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(nivelAcademicoService.Get());
        }
        [HttpPost]
        public IActionResult Post([FromBody] NivelAcademico nivelAcademico)
        {
            nivelAcademicoService.Save(nivelAcademico);
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] NivelAcademico nivelAcademico)
        {
            nivelAcademicoService.Update(id, nivelAcademico);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            nivelAcademicoService.Delete(id);
            return Ok();
        }
    }
}
