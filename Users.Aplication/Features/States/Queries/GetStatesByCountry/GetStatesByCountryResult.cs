namespace Users.Aplication.Features.States.Queries.GetStatesByCountry ;
using Models.Common.DTO;

    public class GetStatesByCountryResult : ReferencialTableDTO
    {
        public Guid CountryId { get; set; }
    }
