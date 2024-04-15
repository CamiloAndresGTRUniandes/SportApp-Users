namespace Users.Aplication.Features.Cities.Queries.GetCityByState ;
using MediatR;

    public class GetCityByStateQuery : IRequest<List<GetCityByStateResult>>
    {
        public Guid StateId { get; set; }
    }
