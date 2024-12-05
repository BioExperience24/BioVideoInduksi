using FluentValidation;
using Microsoft.AspNetCore.Http;
using CleanArchitecture.Web.Requests;

namespace CleanArchitecture.Web.Validations
{
    public class PlayerGroupRequestAddValidation : AbstractValidator<PlayerGroupAddRequest>
    {
        public PlayerGroupRequestAddValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.");
        }
    }
}
