using FluentValidation;
using CleanArchitecture.Application.Common.Models.Signage;

public abstract class SignageRequestValidation<T> : AbstractValidator<T> where T : SignageRequest
{
    public SignageRequestValidation()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required.");

        RuleFor(x => x.TemplateId)
            .GreaterThan(0)
            .WithMessage("Template is required.");

        RuleFor(x => x.MediaIds)
            .NotEmpty()
            .WithMessage("Media is required.");

        RuleFor(x => x.RunningText)
           .NotEmpty()
           .WithMessage("Running Text is required.");

        RuleFor(x => x.TextColor)
            .NotEmpty()
            .WithMessage("Text color is required.");

        RuleFor(x => x.BackgroundColor)
            .NotEmpty()
            .WithMessage("Background color is required.");

        RuleFor(x => x.FontSize)
            .GreaterThan(0)
            .WithMessage("Font size is required.");

        RuleFor(x => x.TextSpeed)
            .NotEmpty()
            .WithMessage("Text speed is required.");

        // RuleFor(x => x.FontRotate)
        //     .NotEmpty()
        //     .WithMessage("Font rotate is required.");

        // RuleFor(x => x.SignageScroll)
        //     .NotEmpty()
        //     .WithMessage("Signage scroll is required.")
        //     .Must(x => x == "Horizontal" || x == "Vertical")
        //     .WithMessage("Signage scroll must be Horizontal or Vertical.");
    }
}
