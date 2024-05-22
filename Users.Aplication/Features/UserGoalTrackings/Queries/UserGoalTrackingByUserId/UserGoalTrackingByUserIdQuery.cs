namespace Users.Application.Features.UserGoalTrackings.Queries.UserGoalTrackingByUserId ;
using MediatR;

    public class UserGoalTrackingByUserIdQuery : IRequest<UserGoalTrackingByUserIdResult>
    {
        public string UserId { get; set; }
    }
