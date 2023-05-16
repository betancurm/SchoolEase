using ApischoolEase.Models;
using ApischoolEase.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApischoolEase.Controllers
{
    [Route("api/[controller]")]
    public class PlanEstudioController : ControllerBase
    {
        IPlanEstudioService planEstudioService;
        public PlanEstudioController(IPlanEstudioService service)
        {
            planEstudioService = service;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(planEstudioService.Get());
        }
        [HttpPost]
        public IActionResult Post([FromBody] PlanEstudio planEstudio)
        {
            planEstudioService.Save(planEstudio);
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] PlanEstudio planEstudio)
        {
            planEstudioService.Update(id, planEstudio);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            planEstudioService.Delete(id);
            return Ok();
        }
    }
}
