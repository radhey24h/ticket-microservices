using FluentValidation;

namespace FMECA.Application.Features.MetadataFMECA.Commands.Insert;
public class CreateFMECADetailsCommandValidator : AbstractValidator<CreateFMECADetailsCommand>
{
    public CreateFMECADetailsCommandValidator()
    {
        RuleFor(p => p.FMECAName)
               .NotEmpty().WithMessage("{FMECAName} is required.")
               .NotNull()
               .MaximumLength(100).WithMessage("{FMECAName} must not exceed 100 characters.");
    }
}
