using Microsoft.AspNetCore.Mvc;
using Vmmsolutions.School.Application.Dto.Students;
using Vmmsolutions.School.Application.Interface;

namespace Vmmsolutions.School.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/students")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentAppService _studentsAppService;
        private readonly ILogger<StudentController> _logger;

        public StudentController(ILogger<StudentController> logger, IStudentAppService StudentsAppService)
        {
            this._studentsAppService = StudentsAppService;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            return Ok(_studentsAppService.GetById(id));
        }

        [HttpGet()]
        public IActionResult GetAll()
        {
            var result = Enumerable.Range(1, 5).Select(index => new StudentDto
            {
                Id = Guid.NewGuid(),
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now,
            }).ToList();

            return Ok(result);
        }


        [HttpPost()]
        [ProducesResponseType(typeof(StudentDto), 201)]
        //[ProducesResponseType(typeof(Error), 400)]
        //[ProducesResponseType(typeof(Error), 500)]
        public IActionResult Post([FromBody] StudentPostDto value)
        {
            StudentDto result = _studentsAppService.Insert(value);
            return Created("", result);
        }


        [HttpPatch("{id}")]
        //[ProducesResponseType(typeof(Error), 400)]
        //[ProducesResponseType(typeof(Error), 500)]
        public IActionResult Patch([FromRoute] Guid id, [FromBody] StudentPatchDto value)
        {
            _studentsAppService.Update(id, value);
            return NoContent();
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(void), 204)]
        //[ProducesResponseType(typeof(Error), 400)]
        //[ProducesResponseType(typeof(Error), 500)]
        public IActionResult Delete([FromRoute] Guid id)
        {
            _studentsAppService.Delete(id);
            return NoContent();
        }
    }
}
