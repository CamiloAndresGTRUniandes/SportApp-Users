namespace Users.Application.Features.ProductEventSuscriptions.Commands.ProductEventSuscriptionSave ;
using FluentValidation;

    public class ProductEventSuscriptionValidation : AbstractValidator<ProductEventSuscriptionSaveCommnand>
    {
        public ProductEventSuscriptionValidation()
        {
            RuleFor(p => p.ProductId).NotEmpty();
            RuleFor(p => p.Name).NotEmpty();
            RuleFor(p => p.CategoryId).NotEmpty();
            RuleFor(p => p.CategoryName).NotEmpty();
            RuleFor(p => p.PlanId).NotEmpty();
            RuleFor(p => p.PlanName).NotEmpty();
            RuleFor(p => p.UserId).NotEmpty();
            RuleFor(p => p.UserId).NotEmpty();
            RuleFor(p => p.StartDateTime).NotEmpty();
            RuleFor(p => p.EndDateTime).NotEmpty();
        }
    }
