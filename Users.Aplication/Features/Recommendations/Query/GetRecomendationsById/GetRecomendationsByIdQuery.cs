namespace Users.Application.Features.Recommendations.Query.GetRecomendationsById ;
using MediatR;
using Recomendations.Query.GetRecomendationsById;

    public class GetRecomendationsByIdQuery : IRequest<GetRecommendationsByIdResult>
    {
        public Guid Id { get; set; }
    }
