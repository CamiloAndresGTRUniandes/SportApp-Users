namespace Users.Aplication.Features.Cities.Queries.GetCityById ;
using MediatR;

    public class GetCityByIdQuery : IRequest<List<GetCityByIdResult>>
    {
        public Guid CityId { get; set; }
    }
