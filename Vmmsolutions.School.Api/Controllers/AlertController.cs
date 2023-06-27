using Microsoft.AspNetCore.Mvc;
using Vmmsolutions.School.Application.Dto.Alert;
using Vmmsolutions.School.Application.Interface;

namespace Vmmsolutions.School.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/alerts")]
    [ApiController]
    public class AlertController : ControllerBase
    {
        private readonly IAlertAppService _alertAppService;

        private readonly ILogger<AlertController> _logger;

        public AlertController(ILogger<AlertController> logger, IAlertAppService AlertsAppService)
        {
            this._alertAppService = AlertsAppService;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            return Ok(_alertAppService.GetById(id));
        }

        [HttpGet()]
        public IActionResult GetAll()
        {
            var result = Enumerable.Range(1, 5).Select(index => new AlertDto
            {
                Id = Guid.NewGuid(),
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now,
            }).ToList();

            return Ok(result);
        }


        [HttpPost()]
        [ProducesResponseType(typeof(AlertDto), 201)]
        //[ProducesResponseType(typeof(Error), 400)]
        //[ProducesResponseType(typeof(Error), 500)]
        public IActionResult Post([FromBody] AlertPostDto value)
        {
            AlertDto result = _alertAppService.Insert(value);
            return Created("", result);
        }


        [HttpPatch("{id}")]
        //[ProducesResponseType(typeof(Error), 400)]
        //[ProducesResponseType(typeof(Error), 500)]
        public IActionResult Patch([FromRoute] Guid id, [FromBody] AlertPatchDto value)
        {
            _alertAppService.Update(id, value);
            return NoContent();
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(void), 204)]
        //[ProducesResponseType(typeof(Error), 400)]
        //[ProducesResponseType(typeof(Error), 500)]
        public IActionResult Delete([FromRoute] Guid id)
        {
            _alertAppService.Delete(id);
            return NoContent();
        }
    }
}
