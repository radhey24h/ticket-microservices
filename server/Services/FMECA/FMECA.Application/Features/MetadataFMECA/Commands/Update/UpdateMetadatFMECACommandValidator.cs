using FluentValidation;

namespace FMECA.Application.Features.MetadataFMECA.Commands.Update;
public class UpdateMetadatFMECACommandValidator : AbstractValidator<UpdateMetadatFMECACommand>
{
    public UpdateMetadatFMECACommandValidator()
    {
        RuleFor(p => p.FMECANumber)
               .NotEmpty().WithMessage("{FMECAName} is required.")
               .NotNull()
               .MaximumLength(100).WithMessage("{FMECAName} must not exceed 100 characters.");
    }
}
