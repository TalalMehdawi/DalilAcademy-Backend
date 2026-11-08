using System;

using DalilAcademy.Core.Entities;
using DalilAcademy.Core.Exceptions;
using DalilAcademy.Core.Mappings;
using DalilAcademy.Core.Repository;
using DalilAcademy.Core.Service;

using FluentValidation;
namespace DalilAcademy.Infra.Service;

public class EnrollmentService(IEnrollmentRepository enrollmentRepository
, IValidator<EnrollStudentDto> validator
, IStudentRepository studentRepository,
ICourseRepository courseRepository) : IEnrollmentService
{
    public async Task<List<EnrollmentDto>> GetByCourseId(int courseId)
    {
        var resulte = await enrollmentRepository.GetByCourseId(courseId);

        return resulte.Select(e => e.ToDto()).ToList();
    }
    public async Task<List<EnrollmentDto>> GetByStudentId(int studentId)
    {
        var resulte = await enrollmentRepository.GetByStudentId(studentId);
        return resulte.Select(e => e.ToDto()).ToList();

    }
    public async Task<EnrollmentDto> Create(EnrollStudentDto enrollment)
    {
        await validator.ValidateAndThrowAsync(enrollment);
        var student = await studentRepository.GetById(enrollment.StudentId) ??
         throw new NotFoundException("studet with this id dose not exist...!");

        var course = await courseRepository.GetById(enrollment.CourseId) ??
         throw new NotFoundException("course with this id dose not exist...!");

        if (await enrollmentRepository.ExistsAsync(enrollment.StudentId, enrollment.CourseId))
            throw new ConflictException("this Student already enrolled in this course..!");

        var resulte = await enrollmentRepository.Create(enrollment.ToEntity());

        resulte.Course = course;
        resulte.Student = student;
        return resulte.ToDto();

    }
    public async Task Delete(int studentId, int courseId )
    {
        if (!await enrollmentRepository.Delete(courseId, studentId))
        {
            throw new NotFoundException("this enrollment dose not exist");
        }


    }


}