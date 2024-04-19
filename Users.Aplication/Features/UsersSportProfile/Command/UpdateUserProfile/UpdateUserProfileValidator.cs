namespace Users.Aplication.Features.UsersSportProfile.Command.UpdateUserProfile ;
using FluentValidation;

    public class UpdateUserProfileValidator : AbstractValidator<UpdateUserSportProfileCommand>
    {
        public UpdateUserProfileValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .MaximumLength(100);
            RuleFor(p => p.LastName)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(p => p.Email)
                .NotEmpty()
                .EmailAddress();
            RuleFor(p => p.PhoneNumber)
                .MaximumLength(25);

            RuleFor(p => p.DateOfBirth)
                .LessThan(DateTime.UtcNow.Date);
        }
    }
