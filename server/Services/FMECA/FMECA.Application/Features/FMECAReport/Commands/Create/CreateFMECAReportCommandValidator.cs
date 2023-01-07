using FluentValidation;

namespace FMECA.Application.Features.FMECAReport.Commands.Insert;
public class CreateFMECAReportCommandValidator : AbstractValidator<CreateFMECAReportCommand>
{
    public CreateFMECAReportCommandValidator()
    {
        RuleFor(p => p.ReportName)
               .NotEmpty().WithMessage("{ReportName} is required.")
               .NotNull()
               .MaximumLength(100).WithMessage("{ReportName} must not exceed 100 characters.");
    }
}
