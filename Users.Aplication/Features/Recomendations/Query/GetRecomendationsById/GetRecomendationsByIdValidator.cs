namespace Users.Application.Features.Recomendations.Query.GetRecomendationsById ;
using FluentValidation;

    public class GetRecomendationsByIdValidator : AbstractValidator<GetRecomendationsByIdQuery>
    {
        public GetRecomendationsByIdValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty();
        }
    }
