namespace Users.Aplication.Features.States.Queries.GetStatesByCountry ;
using MediatR;

    public class GetStatesByCountryQuery : IRequest<List<GetStatesByCountryResult>>
    {
        public Guid CountryId { get; set; }
    }
