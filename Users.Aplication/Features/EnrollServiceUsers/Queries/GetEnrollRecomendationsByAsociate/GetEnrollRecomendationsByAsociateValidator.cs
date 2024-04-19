namespace Users.Application.Features.EnrollServiceUsers.Queries.GetEnrollRecomendationsByAsociate ;
using FluentValidation;

    public class GetEnrollRecomendationsByAsociateValidator : AbstractValidator<GetEnrollRecomendationsByAsociateQuery>
    {
        public GetEnrollRecomendationsByAsociateValidator()
        {
            RuleFor(p => p.UserId)
                .NotEmpty();
        }
    }
