using MediatR;

namespace Users.Aplication.Features.UsersSportProfile.Queries.GetUserById
{
    public class GetUserByIdQuery:IRequest<GetUserByIdQueryResult>
    {
        public string UserId { get; set; } = string.Empty;
    }
}
