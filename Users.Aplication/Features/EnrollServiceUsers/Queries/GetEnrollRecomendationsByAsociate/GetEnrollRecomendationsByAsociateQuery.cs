namespace Users.Application.Features.EnrollServiceUsers.Queries.GetEnrollRecomendationsByAsociate ;
using MediatR;

    public class GetEnrollRecomendationsByAsociateQuery : IRequest<List<GetEnrollRecomendationsByAsociateResult>>
    {
        public string UserId { get; set; }
    }
