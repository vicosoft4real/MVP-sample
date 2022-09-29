using FluentValidation;

namespace Application.Features.AgreementManagement.Requests;

public class AgreementUpdateValidation: AbstractValidator<UpdateAgreementRequest>
{
    public AgreementUpdateValidation()
    {
        RuleFor(x => x.Expiration)
            .NotEmpty()
            .WithMessage("The expiration date must be in the future");
        RuleFor(x => x.EffectiveDate).NotEmpty().WithMessage("The Effective date must be set");
        RuleFor(x => x.GroupId).NotEmpty().WithMessage("The group id is required to create agreement");
        RuleFor(x => x.NewPrice).GreaterThan(0.0M).WithMessage("The price cannot be negative");
        RuleFor(x => x.ProductId).NotEmpty().WithMessage("The product id is required");
        RuleFor(x => x.ProductPrice).NotEmpty().WithMessage("The product price must be set");
        RuleFor(x => x.UserId).NotEmpty().WithMessage("The user id must be set");
        
    }

    public static AgreementUpdateValidation Create() => new();
}