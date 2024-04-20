namespace Users.Application.Features.Recomendations.Query.GetRecomendationsByUser ;
using FluentValidation;

    public class GetRecomendationsByUserValidator : AbstractValidator<GetRecomendationsByUserQuery>
    {
        public GetRecomendationsByUserValidator()
        {
            RuleFor(p => p.UserId)
                .NotEmpty();

            RuleFor(p => p.TypeOfRecommendation).NotEmpty();
        }
    }
