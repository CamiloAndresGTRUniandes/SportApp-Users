using MediatR;

namespace Users.Aplication.Features.Activities.Queries.GetAllActivities
{
    public class GetAllActivitiesQuery:IRequest<List<GetAllActivitiesResult>>
    {
    }
}
