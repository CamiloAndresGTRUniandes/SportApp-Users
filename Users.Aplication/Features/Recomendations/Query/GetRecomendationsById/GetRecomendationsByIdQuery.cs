namespace Users.Application.Features.Recomendations.Query.GetRecomendationsById ;
using MediatR;

    public class GetRecomendationsByIdQuery : IRequest<GetRecomendationsByIdResult>
    {
        public Guid Id { get; set; }
    }
