using FluentValidation;
using CleanArchitecture.Application.Common.Models.Signage;

public class SignageRequestUpdateValidation : SignageRequestValidation<SignageRequestUpdate>
{
    public SignageRequestUpdateValidation()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage("Id is required.");
    }
}
