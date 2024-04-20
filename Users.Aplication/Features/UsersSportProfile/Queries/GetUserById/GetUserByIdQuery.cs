namespace Users.Aplication.Features.UsersSportProfile.Queries.GetUserById ;
using MediatR;

    public class GetUserByIdQuery : IRequest<GetUserByIdQueryResult>
    {
        public string UserId { get; set; } = string.Empty;
    }
