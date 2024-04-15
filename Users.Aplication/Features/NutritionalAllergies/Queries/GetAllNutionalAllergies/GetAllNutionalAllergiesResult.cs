using Users.Aplication.Models.Common.DTO;

namespace Users.Aplication.Features.NutritionalAllergies.Queries.GetAllNutionalAllergies
{
    public class GetAllNutionalAllergiesResult:ReferencialTableDTO
    {
        public bool Selected { get; set; } = false;
    }
}
