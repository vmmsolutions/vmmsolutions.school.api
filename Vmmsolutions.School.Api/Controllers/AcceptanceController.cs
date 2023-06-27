using Microsoft.AspNetCore.Mvc;
using Vmmsolutions.School.Application.Dto.Acceptances;
using Vmmsolutions.School.Application.Interface;

namespace Vmmsolutions.School.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/acceptances")]
    [ApiController]
    public class AcceptanceController : ControllerBase
    {
        private readonly IAcceptanceAppService _acceptanceAppService;
        private readonly ILogger<AcceptanceController> _logger;

        public AcceptanceController(ILogger<AcceptanceController> logger, IAcceptanceAppService AcceptancesAppService)
        {
            this._acceptanceAppService = AcceptancesAppService;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            return Ok(_acceptanceAppService.GetById(id));
        }

        [HttpGet()]
        public IActionResult GetAll()
        {
            var result = Enumerable.Range(1, 5).Select(index => new AcceptanceDto
            {
                Id = Guid.NewGuid(),
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now,
            }).ToList();

            return Ok(result);
        }


        [HttpPost()]
        [ProducesResponseType(typeof(AcceptanceDto), 201)]
        //[ProducesResponseType(typeof(Error), 400)]
        //[ProducesResponseType(typeof(Error), 500)]
        public IActionResult Post([FromBody] AcceptancePostDto value)
        {
            AcceptanceDto result = _acceptanceAppService.Insert(value);
            return Created("", result);
        }


        [HttpPatch("{id}")]
        //[ProducesResponseType(typeof(Error), 400)]
        //[ProducesResponseType(typeof(Error), 500)]
        public IActionResult Patch([FromRoute] Guid id, [FromBody] AcceptancePatchDto value)
        {
            _acceptanceAppService.Update(id, value);
            return NoContent();
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(void), 204)]
        //[ProducesResponseType(typeof(Error), 400)]
        //[ProducesResponseType(typeof(Error), 500)]
        public IActionResult Delete([FromRoute] Guid id)
        {
            _acceptanceAppService.Delete(id);
            return NoContent();
        }
    }
}
