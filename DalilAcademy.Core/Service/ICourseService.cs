using DalilAcademy.Core.DTOs;

namespace DalilAcademy.Core.Service;
using DalilAcademy.Core.Entities;
public interface ICourseService
{

    Task<PageResulte<ResponseCourseDto>> GetAll(int page,int pageSize);
    
    Task<ResponseCourseDto?> GetById(int id);

    Task<ResponseCourseDto?> Create(CreateCourseDto course);

    Task<Course?> Update(Course course);

    Task Delete(int id);
}