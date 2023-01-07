using FluentValidation;

namespace FMECA.Application.Features.FMECA.Commands.Insert;
public class CreateFMECACommandValidator : AbstractValidator<CreateFMECACommand>
{
    public CreateFMECACommandValidator()
    {
        RuleFor(p => p.FMECANumber)
               .NotEmpty().WithMessage("{FMECAName} is required.")
               .NotNull()
               .MaximumLength(100).WithMessage("{FMECAName} must not exceed 100 characters.");
    }
}
