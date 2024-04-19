namespace Users.Application.Features.Recommendations.Command.CreateUserRecommendation ;
using MediatR;

    public class CreateUserRecommendationCommand : IRequest<Unit>
    {
        public string UserId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string UserAsociateId { get; set; }
        public Guid TypeOfRecommendationId { get; set; }
        public Guid EnrollServiceUserId { get; set; }
    }
