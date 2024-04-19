namespace Users.Application.Features.Recomendations.Query.GetRecomendationsByAsociate ;
using FluentValidation;

    public class GetRecomendationsByAsociateValidator : AbstractValidator<GetRecomendationsByAsociateQuery>
    {
        public GetRecomendationsByAsociateValidator()
        {
            RuleFor(p => p.UserId)
                .NotEmpty();
        }
    }
