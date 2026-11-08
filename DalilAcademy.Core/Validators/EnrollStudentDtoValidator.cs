using System;

using DalilAcademy.Core.DTOs;

using FluentValidation;
namespace DalilAcademy.Core.Validators;

public class EnrollStudentDtoValidator : AbstractValidator<EnrollStudentDto>
{
    public EnrollStudentDtoValidator()
    {
        RuleFor(x => x.StudentId)
            .GreaterThan(0).WithMessage("StudentId must be greater than 0");

        RuleFor(x => x.CourseId)
            .GreaterThan(0).WithMessage("CourseId must be greater than 0");
    }


}