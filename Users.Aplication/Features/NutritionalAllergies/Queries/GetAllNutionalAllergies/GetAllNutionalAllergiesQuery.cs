using MediatR;

namespace Users.Aplication.Features.NutritionalAllergies.Queries.GetAllNutionalAllergies
{
    public class GetAllNutionalAllergiesQuery : IRequest<List<GetAllNutionalAllergiesResult>> { }
    
}
