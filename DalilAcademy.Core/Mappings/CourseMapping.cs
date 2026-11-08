using DalilAcademy.Core.DTOs;
using DalilAcademy.Core.Entities;

namespace DalilAcademy.Core.Mappings;

public static class CourseMapping
{
    public static ResponseCourseDto ToDto(this Course course)
    {
        return new ResponseCourseDto(course.Id, course.Title, course.Price, course.Instructor?.FullName);
    }

    public static Course ToEntity(this CreateCourseDto dto)
    {
        return new Course
        {
            Title = dto.Title,
            Price = dto.Price,
            InstructorId = dto.InstructorId
        };

    }
}