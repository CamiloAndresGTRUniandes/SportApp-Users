namespace Users.Application.Features.EnrollServiceUsers.Commands.CreateEnrollServiceUser ;
using FluentValidation;

    public class CreateEnrollServiceUserValidator : AbstractValidator<CreateEnrollServiceUserCommand>
    {
        public CreateEnrollServiceUserValidator()
        {
            RuleFor(p => p.UserId).NotEmpty();
            RuleFor(p => p.UserAsociateId).NotEmpty();
            RuleFor(p => p.ServiceId).NotEmpty();
            RuleFor(p => p.ServiceName).NotEmpty();
            RuleFor(p => p.Description).NotEmpty();
            RuleFor(p => p.PlanId).NotEmpty();
            RuleFor(p => p.CategoryId).NotEmpty();
            RuleFor(p => p.CategoryName).NotEmpty();
        }
    }
