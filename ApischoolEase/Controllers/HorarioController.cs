using ApischoolEase.Models;
using ApischoolEase.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApischoolEase.Controllers
{
    [Route("api/[controller]")]
    public class HorarioController: ControllerBase
    {
         IHorarioService horarioService;
        public HorarioController(IHorarioService service)
        {
            horarioService = service;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(horarioService.Get());
        }
        [HttpPost]
        public IActionResult Post([FromBody] Horario horario)
        {
            horarioService.Save(horario);
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Horario horario)
        {
            horarioService.Update(id, horario);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            horarioService.Delete(id);
            return Ok();
        }
    }
}
