using DalilAcademy.Core.DTOs;

using FluentValidation;

namespace DalilAcademy.Core.Validators;

public class UpdateStudentDtoValidator : AbstractValidator<UpdateStudentDto>
{
    public UpdateStudentDtoValidator()
    {
        RuleFor(S => S.FullName).NotEmpty().MaximumLength(200)
            .WithMessage("FullName Proparty is not Valid...!");
        RuleFor(S => S.Email).NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Email is not valid");
        RuleFor(x => x.Phone)
            .NotEmpty().WithMessage("Phone is required")
            .Length(10).WithMessage("Phone must be exactly 10 digits")
            .Matches(@"^\d+$").WithMessage("Phone must contain digits only");

    }

}