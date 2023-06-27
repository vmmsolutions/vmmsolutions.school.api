using Microsoft.AspNetCore.Mvc;
using Vmmsolutions.School.Application.Dto.Events;
using Vmmsolutions.School.Application.Interface;

namespace Vmmsolutions.School.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/events")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventAppService _eventAppService;
        private readonly ILogger<EventController> _logger;

        public EventController(ILogger<EventController> logger, IEventAppService eventAppService)
        {
            this._eventAppService = eventAppService;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            return Ok(_eventAppService.GetById(id));

        }

        [HttpGet()]
        public IActionResult GetAll()
        {
            var result = Enumerable.Range(1, 5).Select(index => new EventDto
            {
                Id = Guid.NewGuid(),
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now,
            }).ToList();

            return Ok(result);
        }


        [HttpPost()]
        [ProducesResponseType(typeof(EventDto), 201)]
        //[ProducesResponseType(typeof(Error), 400)]
        //[ProducesResponseType(typeof(Error), 500)]
        public IActionResult Post([FromBody] EventPostDto value)
        {
            EventDto result = _eventAppService.Insert(value);
            return Created("", result);
        }


        [HttpPatch("{id}")]
        //[ProducesResponseType(typeof(Error), 400)]
        //[ProducesResponseType(typeof(Error), 500)]
        public IActionResult Patch([FromRoute] Guid id, [FromBody] EventPatchDto value)
        {
            _eventAppService.Update(id, value);
            return NoContent();
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(void), 204)]
        //[ProducesResponseType(typeof(Error), 400)]
        //[ProducesResponseType(typeof(Error), 500)]
        public IActionResult Delete([FromRoute] Guid id)
        {
            _eventAppService.Delete(id);
            return NoContent();
        }
    }
}
