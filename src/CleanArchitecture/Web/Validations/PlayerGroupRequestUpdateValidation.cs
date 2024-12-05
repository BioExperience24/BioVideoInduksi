using FluentValidation;
using Microsoft.AspNetCore.Http;
using CleanArchitecture.Web.Requests;

namespace CleanArchitecture.Web.Validations
{
    public class PlayerGroupRequestUpdateValidation : AbstractValidator<PlayerGroupUpdateRequest>
    {
        public PlayerGroupRequestUpdateValidation()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id is required.");

            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.");
        }
    }
}
