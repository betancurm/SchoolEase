using ApischoolEase.Models;
using ApischoolEase.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApischoolEase.Controllers
{
    [Route("api/[controller]")]
    public class GrupoController : ControllerBase
    {
        IGrupoService grupoService;
        public GrupoController(IGrupoService service)
        {
            grupoService = service;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(grupoService.Get());
        }
        [HttpPost]
        public IActionResult Post([FromBody] Grupo grupo)
        {
            grupoService.Save(grupo);
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Grupo grupo)
        {
            grupoService.Update(id, grupo);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            grupoService.Delete(id);
            return Ok();
        }
    }
}
