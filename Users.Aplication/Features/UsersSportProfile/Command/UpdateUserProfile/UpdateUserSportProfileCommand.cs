using MediatR;
using Users.Aplication.Models.Common.DTO;

namespace Users.Aplication.Features.UsersSportProfile.Command.UpdateUserProfile
{
    public class UpdateUserSportProfileCommand : UserProfileDTO, IRequest<Unit>
    {
    
    }


    
}
