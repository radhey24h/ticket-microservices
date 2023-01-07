using FluentValidation;

namespace FMECA.Application.Features.FMECAReport.Commands.Update;
public class UpdateFMECAReportCommandValidator : AbstractValidator<UpdateFMECAReportCommand>
{
    public UpdateFMECAReportCommandValidator()
    {
        RuleFor(p => p.ReportName)
               .NotEmpty().WithMessage("{ReportName} is required.")
               .NotNull()
               .MaximumLength(100).WithMessage("{ReportName} must not exceed 100 characters.");
    }
}
