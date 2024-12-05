using FluentValidation;
using CleanArchitecture.Web.Requests;

public abstract class PublishRequestValidation<T> : AbstractValidator<T> where T : PublishRequest
{
    public PublishRequestValidation()
    {
        RuleFor(x => x.PlayerId)
            .GreaterThan(0)
            .WithMessage("Player is required.");
        
        RuleFor(x => x.SignageId)
            .GreaterThan(0)
            .WithMessage("Signage is required.");

        RuleFor(x => x.Status)
            .NotEmpty()
            .WithMessage("Status is required.");

        RuleFor(x => x.PublishDate)
            .NotEmpty()
            .WithMessage("Publish date is required.");

        RuleFor(x => x.PublishType)
            .NotEmpty()
            .WithMessage("Publish type is required.");
    }
}