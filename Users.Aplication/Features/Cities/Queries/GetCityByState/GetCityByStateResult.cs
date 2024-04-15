namespace Users.Aplication.Features.Cities.Queries.GetCityByState ;
using Models.Common.DTO;

    public class GetCityByStateResult : ReferencialTableDTO
    {
        public Guid StateId { get; set; }
    }
