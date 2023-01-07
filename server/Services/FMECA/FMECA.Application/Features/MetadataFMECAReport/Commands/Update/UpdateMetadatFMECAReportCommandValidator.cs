using FluentValidation;

namespace FMECA.Application.Features.MetadataFMECAReport.Commands.Update;
public class UpdateMetadatFMECAReportCommandValidator : AbstractValidator<UpdateMetadatFMECAReportCommand>
{
    public UpdateMetadatFMECAReportCommandValidator()
    {
        RuleFor(p => p.FMECANumber)
               .NotEmpty().WithMessage("{FMECAName} is required.")
               .NotNull()
               .MaximumLength(100).WithMessage("{FMECAName} must not exceed 100 characters.");
    }
}
