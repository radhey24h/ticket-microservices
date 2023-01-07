using FluentValidation;

namespace FMECA.Application.Features.MetadataFMECAReport.Commands.Insert;
public class CreateMetadatFMECAReportCommandValidator : AbstractValidator<CreateMetadatFMECAReportCommand>
{
    public CreateMetadatFMECAReportCommandValidator()
    {
        RuleFor(p => p.FMECANumber)
               .NotEmpty().WithMessage("{FMECAName} is required.")
               .NotNull()
               .MaximumLength(100).WithMessage("{FMECAName} must not exceed 100 characters.");
    }
}
