namespace Users.Application.Features.EnrollServiceUsers.Queries.GetEnrollRecomendationById ;
using MediatR;

    public class GetEnrollRecomendationsByIdQuery : IRequest<GetEnrollRecomendationsByIdResult>
    {
        public Guid Id { get; set; }
    }
