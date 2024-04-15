using MediatR;

namespace Users.Aplication.Features.Goals.Queries.GetAllGoals
{
    public class GetAllGoalsQuery:IRequest<List<GetAllGoalsResult>>
    {
    }
}
