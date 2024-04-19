namespace Users.Application.Features.Recomendations.Query.GetRecomendationsByUser ;
using MediatR;

    public class GetRecomendationsByUserQuery : IRequest<List<GetRecomendationsByUserResult>>
    {
        public string UserId { get; set; }
        public Guid Recommendation { get; set; }
    }
