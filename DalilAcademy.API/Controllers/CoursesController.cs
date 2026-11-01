using DalilAcademy.Core.DTOs;
using DalilAcademy.Core.Entities;
using DalilAcademy.Core.Service;
using Microsoft.AspNetCore.Mvc;

namespace DalilAcademy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class  CoursesController(ICourseService courseService) : ControllerBase
    {
       
        [HttpGet]
        public async Task<ActionResult <List<ResponseCourseDto>>> GetAll()
        {
            var courses = await courseService.GetAll();
            return Ok(courses);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ResponseCourseDto>> GetById(int id)
        {
            var course = await courseService.GetById(id);
            if (course is null) return NotFound();
            return Ok(course);
        }


        [HttpPost]
        
        public async Task<ActionResult<Course>> Create(CreateCourseDto dto)
        {
           var created= await courseService.Create(dto);
           if (created is null)
           {
               return BadRequest("Price must be positive");
           }

           return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
           
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await courseService.Delete(id);
            return NoContent();
        }

        [HttpPut]

        public async Task<ActionResult<Course?>> Update(Course course)
        {
            try
            {
             var createdCourse=  await courseService.Update(course);
             return Ok(createdCourse);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }






    }
}
