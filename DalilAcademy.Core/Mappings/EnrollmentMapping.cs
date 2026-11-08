using System;

using DalilAcademy.Core.Entities;
namespace DalilAcademy.Core.Mappings;

public static class EnrollmentMapping
{
    public static EnrollmentDto ToDto(this Enrollment enrollment)
    {
        return new EnrollmentDto(
            enrollment.StudentId,
            enrollment.Student!.FullName,
            enrollment.CourseId,
            enrollment.Course!.Title,
            enrollment.EnrollmentAt);
    }

    // لما يكون عندك الـ student و الـ course جاهزين بالـ service (بعد الـ AddAsync)
    public static EnrollmentDto ToDto(this Enrollment enrollment, Student student, Course course)
    {
        return new EnrollmentDto(
            enrollment.StudentId,
            student.FullName,
            enrollment.CourseId,
            course.Title,
            enrollment.EnrollmentAt);
    }

    public static Enrollment ToEntity(this EnrollStudentDto dto)
    {
        return new Enrollment
        {
            StudentId = dto.StudentId,
            CourseId = dto.CourseId
        };
    }
}