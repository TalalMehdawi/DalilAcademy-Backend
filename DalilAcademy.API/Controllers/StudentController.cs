using DalilAcademy.Core.DTOs;
using DalilAcademy.Core.Service;
using Microsoft.AspNetCore.Mvc;

namespace DalilAcademy.API.Controllers;


    [Route("api/[controller]")]
    [ApiController]
    
    public class StudentController(IStudentService studentService): ControllerBase
    {


        [HttpGet]
        public async Task<ActionResult<PageResulte<ResponseStudentDto>>> GettAll([FromQuery] int page,int pageSize)
        {
            page=Math.Max(page,1);
            pageSize=Math.Clamp(pageSize,1,50);
            return  Ok(await studentService.GetAll(page,pageSize));
        }
        
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ResponseStudentDto>> GetById(int id)
        {
            return  Ok(await studentService.GetById(id));
        }
        
        [HttpGet("{id:int}/courses")]
        public async Task<ActionResult<ResponseStudentDtoWithCourses>> GetByIdWithCourses(int id)
        {
            return  Ok(await studentService.GetByIdWithCourses(id));
        }

        [HttpPost]
        public async Task<ActionResult<ResponseStudentDto>> Create(CreateStudentDto dto)
        {
            return  Ok(await studentService.Create(dto));
        }
        
        [HttpPut("{id:int}")]
        public async Task<ActionResult<ResponseStudentDto>> Update(int id,UpdateStudentDto dto)
        {
            return  Ok(await studentService.Update(id,dto));
        }
        
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ResponseStudentDto>> Delete(int id)
        {
            return  Ok(await studentService.Delete(id));
        }
        

        
    }
