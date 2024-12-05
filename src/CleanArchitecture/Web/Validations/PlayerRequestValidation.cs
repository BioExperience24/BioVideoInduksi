using FluentValidation;
using CleanArchitecture.Web.Requests;

public abstract class PlayerRequestValidation<T> : AbstractValidator<T> where T : PlayerRequest
{
    public PlayerRequestValidation()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required.");

        RuleFor(x => x.Serial)
            .NotEmpty()
            .WithMessage("Serial is required.");
        
        RuleFor(x => x.PlayerGroupId)
            .GreaterThan(0)
            .WithMessage("Player group is required.");
    }
}
