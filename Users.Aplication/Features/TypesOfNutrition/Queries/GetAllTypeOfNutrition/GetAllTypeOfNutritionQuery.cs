using MediatR;

namespace Users.Aplication.Features.TypesOfNutrition.Queries.GetAllTypeOfNutrition
{
    public class GetAllTypeOfNutritionQuery : IRequest<List<GetAllTypeOfNutritionResult>>
    {
    }
}
