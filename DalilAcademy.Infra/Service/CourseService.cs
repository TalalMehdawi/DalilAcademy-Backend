using DalilAcademy.Core.DTOs;
using DalilAcademy.Core.Repository;
using DalilAcademy.Core.Service;
using DalilAcademy.Core.Entities;
using DalilAcademy.Core.Mappings;
using DalilAcademy.Core.Validators;
using FluentValidation;

namespace DalilAcademy.Infra.Service;

public class CourseService(ICourseRepository courseRepository,IValidator<CreateCourseDto> validator) : ICourseService
{

    public async Task<PageResulte<ResponseCourseDto>> GetAll(int page,int pageSize)
    {
        var courses = await courseRepository.GetAll(page,pageSize);
       return courses;
    }

    public async Task<ResponseCourseDto?> GetById(int id)
    {
        var course = await courseRepository.GetById(id);
        if (course is null)
            throw new KeyNotFoundException($"Course {id} not found");
        return course.ToDto();
    }

    public async Task<ResponseCourseDto?> Create(CreateCourseDto course)
    {
        await validator.ValidateAndThrowAsync(course);
        if (course.Price <= 0)
        {
            throw new ArgumentException("Price Must Be Positive");
        } 
        var createdCourse= await courseRepository.Create(course.ToEntity());

      return createdCourse.ToDto();
    }



    public async Task<Course?> Update(Course course)
    {
        if (course.Price <= 0) throw new ArgumentException("Price Must Be Positive");
        
           return await courseRepository.Update(course);
        
    }

    public async Task Delete(int id)
    {
        await courseRepository.Delete(id);
    }
}