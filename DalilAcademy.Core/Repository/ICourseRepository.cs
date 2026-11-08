namespace DalilAcademy.Core.Repository;

using DalilAcademy.Core.DTOs;
using DalilAcademy.Core.Entities;
public interface ICourseRepository
{
    public Task<PageResulte<ResponseCourseDto>>
     GetAll(decimal? minPrice, decimal? maxPrice, int page, int pageSize);
    Task<int> Count();

    Task<Course?> GetById(int id);

    public Task<List<ResponseCourseDto>> GetByStudentId(int id);


    Task<Course> Create(Course course);

    Task<Course?> Update(Course course);

    Task Delete(int id);
}