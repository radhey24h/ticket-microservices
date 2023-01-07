using FluentValidation;

namespace FMECA.Application.Features.FMECA.Commands.Update;
public class UpdateFMECACommandValidator : AbstractValidator<UpdateFMECACommand>
{
    public UpdateFMECACommandValidator()
    {
        RuleFor(p => p.FMECANumber)
               .NotEmpty().WithMessage("{FMECAName} is required.")
               .NotNull()
               .MaximumLength(100).WithMessage("{FMECAName} must not exceed 100 characters.");
    }
}
