namespace DalilAcademy.Core.Repository;
using DalilAcademy.Core.Entities;
using DalilAcademy.Core.DTOs;
public interface ICourseRepository
{
   public  Task<PageResulte<ResponseCourseDto>>
    GetAll(decimal? minPrice, decimal? maxPrice, int page, int pageSize);
    Task<int>Count();

    Task<Course?> GetById(int id);

    Task<Course> Create(Course course);

    Task<Course?> Update(Course course);

    Task Delete(int id);
}