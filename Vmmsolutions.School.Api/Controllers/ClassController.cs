using Microsoft.AspNetCore.Mvc;
using Vmmsolutions.School.Application.Dto.Classes;
using Vmmsolutions.School.Application.Interface;

namespace Vmmsolutions.School.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/classes")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private readonly IClassAppService _classAppService;
        private readonly ILogger<ClassController> _logger;

        public ClassController(ILogger<ClassController> logger, IClassAppService classesAppService)
        {
            this._classAppService = classesAppService;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            return Ok(_classAppService.GetById(id));
        }

        [HttpGet()]
        public IActionResult GetAll()
        {
            var result =  Enumerable.Range(1, 5).Select(index => new ClassDto
            {
                Id = Guid.NewGuid(),
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now,
            }).ToList();

            return Ok(result);
        }

  
        [HttpPost()]
        [ProducesResponseType(typeof(ClassDto), 201)]
        //[ProducesResponseType(typeof(Error), 400)]
        //[ProducesResponseType(typeof(Error), 500)]
        public IActionResult Post([FromBody] ClassPostDto value)
        {
            ClassDto result = _classAppService.Insert(value);
            return Created("", result);
        }

    
        [HttpPatch("{id}")]
        //[ProducesResponseType(typeof(Error), 400)]
        //[ProducesResponseType(typeof(Error), 500)]
        public IActionResult Patch([FromRoute] Guid id, [FromBody] ClassPatchDto value)
        {
            _classAppService.Update(id, value);
            return NoContent();
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(void), 204)]
        //[ProducesResponseType(typeof(Error), 400)]
        //[ProducesResponseType(typeof(Error), 500)]
        public IActionResult Delete([FromRoute] Guid id)
        {
            _classAppService.Delete(id);
            return NoContent();
        }
    }
}
