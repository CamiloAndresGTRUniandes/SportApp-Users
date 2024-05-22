namespace Users.Application.Features.EnrollServiceUsers.Commands.CreateEnrollServiceUser ;
using MediatR;

    public class CreateEnrollServiceUserCommand : IRequest<CreateEnrollServiceUserResult>
    {
        public string UserId { get; set; }
        public string UserAsociateId { get; set; }
        public Guid ServiceId { get; set; }
        public string ServiceName { get; set; }
        public string Description { get; set; }
        public Guid PlanId { get; set; }
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
        public bool WasPayed { get; set; }
    }
