namespace Users.Application.Features.Recommendations.Command.CreateUserRecommendation ;
using FluentValidation;

    public class CreateUserRecommendationValidator : AbstractValidator<CreateUserRecommendationCommand>
    {
        public CreateUserRecommendationValidator()
        {
            RuleFor(p => p.UserId).NotEmpty();
            RuleFor(p => p.Title).NotEmpty();
            RuleFor(p => p.Image).NotEmpty();
            RuleFor(p => p.Description).NotEmpty();
            RuleFor(p => p.UserAsociateId).NotEmpty();
            RuleFor(p => p.EnrollServiceUserId).NotEmpty();
            RuleFor(p => p.TypeOfRecommendationId).NotEmpty();
        }
    }
