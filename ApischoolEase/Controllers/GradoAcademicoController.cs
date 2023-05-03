using ApischoolEase.Models;
using ApischoolEase.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApischoolEase.Controllers
{
    [Route("api/[controller]")]
    public class GradoAcademicoController : ControllerBase
    {
        IGradoAcademicoService gradoAcademicoService;
        public GradoAcademicoController(IGradoAcademicoService service)
        {
            gradoAcademicoService = service;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(gradoAcademicoService.Get());
        }
        [HttpPost]
        public IActionResult Post([FromBody] GradoAcademico gradoAcademico)
        {
            gradoAcademicoService.Save(gradoAcademico);
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] GradoAcademico gradoAcademico)
        {
            gradoAcademicoService.Update(id, gradoAcademico);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            gradoAcademicoService.Delete(id);
            return Ok();
        }
    }
}
