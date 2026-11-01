using DalilAcademy.Core.DTOs;
using DalilAcademy.Core.Service;
using Microsoft.AspNetCore.Mvc;

namespace DalilAcademy.API.Controllers;


    [Route("api/[controller]")]
    [ApiController]
    
    public class StudentController(IStudentService studentService): ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<ResponseStudentDto>>> GettAll()
        {
            return  Ok(await studentService.GetAll());
        }
        
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ResponseStudentDto>> GetById(int id)
        {
            return  Ok(await studentService.GetById(id));
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
