using Microsoft.AspNetCore.Mvc;
using Vmmsolutions.School.Application.Dto.Attachments;
using Vmmsolutions.School.Application.Interface;

namespace Vmmsolutions.School.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/attachments")]
    [ApiController]
    public class AttachmentController : ControllerBase
    {
        private readonly IAttachmentAppService _AttachmentAppService;
        private readonly ILogger<AttachmentController> _logger;

        public AttachmentController(ILogger<AttachmentController> logger, IAttachmentAppService AttachmentsAppService)
        {
            this._AttachmentAppService = AttachmentsAppService;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            return Ok(_AttachmentAppService.GetById(id));
        }

        [HttpGet()]
        public IActionResult GetAll()
        {
            var result = Enumerable.Range(1, 5).Select(index => new AttachmentDto
            {
                Id = Guid.NewGuid(),
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now,
            }).ToList();

            return Ok(result);
        }


        [HttpPost()]
        [ProducesResponseType(typeof(AttachmentDto), 201)]
        //[ProducesResponseType(typeof(Error), 400)]
        //[ProducesResponseType(typeof(Error), 500)]
        public IActionResult Post([FromBody] AttachmentPostDto value)
        {
            AttachmentDto result = _AttachmentAppService.Insert(value);
            return Created("", result);
        }


        [HttpPatch("{id}")]
        //[ProducesResponseType(typeof(Error), 400)]
        //[ProducesResponseType(typeof(Error), 500)]
        public IActionResult Patch([FromRoute] Guid id, [FromBody] AttachmentPatchDto value)
        {
            _AttachmentAppService.Update(id, value);
            return NoContent();
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(void), 204)]
        //[ProducesResponseType(typeof(Error), 400)]
        //[ProducesResponseType(typeof(Error), 500)]
        public IActionResult Delete([FromRoute] Guid id)
        {
            _AttachmentAppService.Delete(id);
            return NoContent();
        }
    }
}
