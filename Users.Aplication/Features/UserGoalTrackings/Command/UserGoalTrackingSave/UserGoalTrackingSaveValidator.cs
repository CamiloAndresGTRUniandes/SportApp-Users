namespace Users.Application.Features.UserGoalTrackings.Command.UserGoalTrackingSave ;
using FluentValidation;

    public class UserGoalTrackingSaveValidator : AbstractValidator<UserGoalTrackingSaveCommand>
    {
        public UserGoalTrackingSaveValidator()
        {
            RuleFor(p => p.KgOfMuscleGained).NotEmpty();
            RuleFor(p => p.PrInFlatBenchPress).NotEmpty();
            RuleFor(p => p.CmsInArm).NotEmpty();
            RuleFor(p => p.PrInSquad).NotEmpty();
            RuleFor(p => p.UserId).NotEmpty();
            RuleFor(p => p.UserAsociateId).NotEmpty();
        }
    }
