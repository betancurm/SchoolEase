
using ApischoolEase.Models;
using ApischoolEase.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApischoolEase.Controllers
{
    [Route("api/[controller]")]
    public class PeriodoAcademicoController : ControllerBase
    {
        IPeriodoAcademicoService periodoAcademicoService;
        public PeriodoAcademicoController(IPeriodoAcademicoService service)
        {
            periodoAcademicoService = service;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(periodoAcademicoService.Get());
        }
        [HttpPost]
        public IActionResult Post([FromBody] PeriodoAcademico periodoAcademico)
        {
            periodoAcademicoService.Save(periodoAcademico);
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id ,[FromBody] PeriodoAcademico periodoAcademico)
        {
            periodoAcademicoService.Update(id, periodoAcademico);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            periodoAcademicoService.Delete(id);
            return Ok();
        }
    }
}
