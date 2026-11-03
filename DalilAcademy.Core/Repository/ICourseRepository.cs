namespace DalilAcademy.Core.Repository;
using DalilAcademy.Core.Entities;
using DalilAcademy.Core.DTOs;
public interface ICourseRepository
{
    Task<PageResulte<ResponseCourseDto>> GetAll(int page,int pageSize);
    Task<Course?> GetById(int id);

    Task<Course> Create(Course course);

    Task<Course?> Update(Course course);

    Task Delete(int id);
}