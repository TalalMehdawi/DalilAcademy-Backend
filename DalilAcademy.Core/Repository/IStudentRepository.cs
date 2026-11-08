using DalilAcademy.Core.DTOs;
using DalilAcademy.Core.Entities;

namespace DalilAcademy.Core.Repository;

public interface IStudentRepository
{
    public Task<Student> GetById(int id);

    public Task<ResponseStudentDtoWithCourses?> GetByIdWithCourses(int id);


    Task<PageResulte<ResponseStudentDto>> GetAll(int page, int pageSize);

    public Task<Student> Create(Student student);

    public Task<Student> Update(int Id, Student student);

    public Task<Student> Delete(int id);

}