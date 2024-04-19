namespace Users.Application.Features.EnrollServiceUsers.Queries.GetEnrollRecomendationById;
using FluentValidation;

    public class GetEnrollRecomendationsByIdValidator : AbstractValidator<GetEnrollRecomendationsByIdQuery>
    {
        public GetEnrollRecomendationsByIdValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty();
        }
    }
