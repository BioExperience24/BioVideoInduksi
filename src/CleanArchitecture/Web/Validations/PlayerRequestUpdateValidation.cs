using FluentValidation;
using CleanArchitecture.Web.Requests;

public class PlayerRequestUpdateValidation : PlayerRequestValidation<PlayerUpdateRequest>
{
    public PlayerRequestUpdateValidation()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage("Id is required.");
    }
}
