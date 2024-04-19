namespace Users.Aplication.Features.UsersSportProfile.Command.UpdateUserProfile ;
using MediatR;
using Models.Common.DTO;

    public class UpdateUserSportProfileCommand : UserProfileDTO, IRequest<Unit>
    {
    }
