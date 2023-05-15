
using ApischoolEase.Models;
using ApischoolEase.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApischoolEase.Controllers
{
    [Route("api/[controller]")]
    public class DocenteController : ControllerBase
    {
        IDocenteService DocenteService;
        public DocenteController(IDocenteService service)
        {
            DocenteService = service;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(DocenteService.Get());
        }
        [HttpPost]
        public IActionResult Post([FromBody] Docente docente)
        {
            DocenteService.Save(docente);
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Docente docente)
        {
            DocenteService.Update(id, docente);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            DocenteService.Delete(id);
            return Ok();
        }
    }
}
