using FluentValidation;
using CleanArchitecture.Web.Requests;

public class PublishRequestUpdateValidation : PublishRequestValidation<PublishRequestUpdate>
{
    public PublishRequestUpdateValidation()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage("Id is required.");
    }
}