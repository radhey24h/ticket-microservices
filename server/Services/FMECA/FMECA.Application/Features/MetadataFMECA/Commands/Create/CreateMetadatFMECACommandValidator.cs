using FluentValidation;

namespace FMECA.Application.Features.MetadataFMECA.Commands.Insert;
public class CreateMetadatFMECACommandValidator : AbstractValidator<CreateMetadatFMECACommand>
{
    public CreateMetadatFMECACommandValidator()
    {
        RuleFor(p => p.FMECANumber)
               .NotEmpty().WithMessage("{FMECAName} is required.")
               .NotNull()
               .MaximumLength(100).WithMessage("{FMECAName} must not exceed 100 characters.");
    }
}
