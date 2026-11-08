using DalilAcademy.Core.DTOs;

namespace DalilAcademy.Core.Service;

using DalilAcademy.Core.Entities;
public interface ICourseService
{

    public Task<PageResulte<ResponseCourseDto>>
     GetAll(decimal? minPrice, decimal? maxPrice, int page, int pageSize);

    Task<string> Count();

    Task<ResponseCourseDto?> GetById(int id);

    public Task<List<ResponseCourseDto>> GetByStudentId(int id);

    Task<ResponseCourseDto?> Create(CreateCourseDto course);

    Task<Course?> Update(Course course);

    Task Delete(int id);
}