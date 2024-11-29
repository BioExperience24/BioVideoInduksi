using FluentValidation;
using Microsoft.AspNetCore.Http;
using CleanArchitecture.Web.Requests;

namespace CleanArchitecture.Web.Validations
{
    public class TemplateRequestUpdateValidation : AbstractValidator<TemplateRequestUpdate>
    {
        public TemplateRequestUpdateValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name is required.")
                .MaximumLength(100)
                .WithMessage("Name must not exceed 100 characters.");
        }
    }
}
