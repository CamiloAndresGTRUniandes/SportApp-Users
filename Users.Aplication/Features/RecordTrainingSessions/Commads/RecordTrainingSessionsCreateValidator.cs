namespace Users.Application.Features.RecordTrainingSessions.Commads ;
using FluentValidation;

    public class RecordTrainingSessionsCreateValidator : AbstractValidator<RecordTrainingSessionsCreateCommand>
    {
        public RecordTrainingSessionsCreateValidator()
        {
            RuleFor(p => p.ServiceId).NotEmpty();
            RuleFor(p => p.ServiceName).NotEmpty();
            RuleFor(p => p.UserId).NotEmpty();
            RuleFor(p => p.TotalTimeExcercise).NotEmpty();
            RuleFor(p => p.TotalTimeExcercise).Must(IsTimeSpan).WithMessage("it does not have the correct format");
            RuleFor(p => p.TotalCalories).NotEmpty();
            RuleFor(p => p.TotalCalories).GreaterThanOrEqualTo(0);
            RuleFor(p => p.TotalCalories).LessThanOrEqualTo(2500);
            RuleFor(p => p.IntensityId).NotEmpty();
            RuleFor(p => p.FTP).NotEmpty();
            RuleFor(p => p.StartDateTime).NotEmpty();
            RuleFor(p => p.EndDateTime).NotEmpty();
        }

        public bool IsTimeSpan(string value)
        {
            var time = new TimeOnly();
            if (!TimeOnly.TryParse(value, out time))
            {
                return false;
            }
            return true;
        }
    }
