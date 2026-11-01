namespace DalilAcademy.Core.Repository;
using DalilAcademy.Core.Entities;

public interface ICourseRepository
{
    Task<List<Course>> GetAll();

    Task<Course?> GetById(int id);

    Task<Course> Create(Course course);

    Task<Course?> Update(Course course);

    Task Delete(int id);
}