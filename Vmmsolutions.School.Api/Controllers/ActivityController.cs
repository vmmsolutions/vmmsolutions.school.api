using Microsoft.AspNetCore.Mvc;
using Vmmsolutions.School.Application.Dto.Activities;
using Vmmsolutions.School.Application.Interface;

namespace Vmmsolutions.School.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/activities")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private readonly IActivityAppService _activityAppService;
        private readonly ILogger<ActivityController> _logger;

        public ActivityController(ILogger<ActivityController> logger, IActivityAppService ActivitiesAppService)
        {
            this._activityAppService = ActivitiesAppService;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            return Ok(_activityAppService.GetById(id));
        }

        [HttpGet()]
        public IActionResult GetAll()
        {
            var result = Enumerable.Range(1, 5).Select(index => new ActivityDto
            {
                Id = Guid.NewGuid(),
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now,
            }).ToList();

            return Ok(result);
        }


        [HttpPost()]
        [ProducesResponseType(typeof(ActivityDto), 201)]
        //[ProducesResponseType(typeof(Error), 400)]
        //[ProducesResponseType(typeof(Error), 500)]
        public IActionResult Post([FromBody] ActivityPostDto value)
        {
            ActivityDto result = _activityAppService.Insert(value);
            return Created("", result);
        }


        [HttpPatch("{id}")]
        //[ProducesResponseType(typeof(Error), 400)]
        //[ProducesResponseType(typeof(Error), 500)]
        public IActionResult Patch([FromRoute] Guid id, [FromBody] ActivityPatchDto value)
        {
            _activityAppService.Update(id, value);
            return NoContent();
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(void), 204)]
        //[ProducesResponseType(typeof(Error), 400)]
        //[ProducesResponseType(typeof(Error), 500)]
        public IActionResult Delete([FromRoute] Guid id)
        {
            _activityAppService.Delete(id);
            return NoContent();
        }
    }
}
