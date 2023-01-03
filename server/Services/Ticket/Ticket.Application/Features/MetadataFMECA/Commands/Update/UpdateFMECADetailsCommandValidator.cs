using FluentValidation;

namespace FMECA.Application.Features.MetadataFMECA.Commands.Update;
public class UpdateFMECADetailsCommandValidator : AbstractValidator<UpdateFMECADetailsCommand>
{
    public UpdateFMECADetailsCommandValidator()
    {
        RuleFor(p => p.FMECAName)
               .NotEmpty().WithMessage("{FMECAName} is required.")
               .NotNull()
               .MaximumLength(100).WithMessage("{FMECAName} must not exceed 100 characters.");
    }
}
