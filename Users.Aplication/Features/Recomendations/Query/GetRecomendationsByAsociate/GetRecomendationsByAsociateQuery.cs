namespace Users.Application.Features.Recomendations.Query.GetRecomendationsByAsociate ;
using MediatR;

    public class GetRecomendationsByAsociateQuery : IRequest<List<GetRecomendationsByAsociateResult>>
    {
        public string UserId { get; set; }
    }
