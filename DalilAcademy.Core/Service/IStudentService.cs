using DalilAcademy.Core.DTOs;
using DalilAcademy.Core.Entities;

namespace DalilAcademy.Core.Service;

public interface IStudentService
{
    
    Task<PageResulte<ResponseStudentDto>> GetAll(int page,int pageSize);
     
    public Task<ResponseStudentDto> GetById(int id);

    public Task<ResponseStudentDtoWithCourses> GetByIdWithCourses(int id);


    public Task<ResponseStudentDto> Create(CreateStudentDto student);
    
    public Task<ResponseStudentDto> Update(int id,UpdateStudentDto student);

    public Task<ResponseStudentDto> Delete(int id);
}