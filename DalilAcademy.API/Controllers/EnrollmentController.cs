using System.Security.Claims;

using DalilAcademy.Core.Entities;
using DalilAcademy.Core.Service;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DalilAcademy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EnrollmentsController(IEnrollmentService enrollmentService) : ControllerBase
    {
        [HttpGet("me")]
        [Authorize(Roles = Roles.Student)]
        public async Task<ActionResult<List<EnrollmentDto>>> GetMyEnrollments()
        {
            var value = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!int.TryParse(value, out var userId))
                throw new UnauthorizedAccessException("Id must be number");
            return Ok(await enrollmentService.GetByStudentId(userId));
        }

        [HttpPost]
        [Authorize(Roles = Roles.Admin)]

        public async Task<IActionResult> Create(EnrollStudentDto dto)
        {
            var result = await enrollmentService.Create(dto);
            return Created(string.Empty, result);
        }

        [HttpDelete("{studentId:int}/{courseId:int}")]
        [Authorize(Roles = Roles.Admin)]
        public async Task<IActionResult> Delete(int studentId, int courseId)
        {
            await enrollmentService.Delete(studentId, courseId);
            return NoContent();
        }

        [HttpGet("student/{studentId:int}")]
        [Authorize(Roles = Roles.Admin)]
        public async Task<IActionResult> GetByStudentId(int studentId)
        {
            return Ok(await enrollmentService.GetByStudentId(studentId));
        }

        [HttpGet("course/{courseId:int}")]
        [Authorize(Roles = Roles.Admin)]
        public async Task<IActionResult> GetByCourseId(int courseId)
        {
            return Ok(await enrollmentService.GetByCourseId(courseId));
        }

    }
}