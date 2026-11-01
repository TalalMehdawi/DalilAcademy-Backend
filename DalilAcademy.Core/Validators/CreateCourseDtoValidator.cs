using DalilAcademy.Core.DTOs;
using FluentValidation;

namespace DalilAcademy.Core.Validators;

public class CreateCourseDtoValidator : AbstractValidator<CreateCourseDto>
{
    public CreateCourseDtoValidator()
    {
        RuleFor(c => c.Price).GreaterThanOrEqualTo(0).WithMessage("Price Must be Equal to or greater than zero");
        RuleFor(c => c.Title).NotEmpty().MaximumLength(200).WithMessage("Title is Required...!");
        RuleFor(c => c.InstructorId).GreaterThan(0).WithMessage("Instructor Id Must Be Positive");
        
    }
}