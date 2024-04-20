namespace Users.Application.Features.UserGoalTrackings.Command.UserGoalTrackingSave ;
using MediatR;

    public class UserGoalTrackingSaveCommand : IRequest<Unit>
    {
        public decimal KgOfMuscleGained { get; set; }
        public decimal PrInFlatBenchPress { get; set; }
        public decimal CmsInArm { get; set; }
        public decimal PrInSquad { get; set; }
        public string UserId { get; set; }
        public string UserAsociateId { get; set; }
    }
