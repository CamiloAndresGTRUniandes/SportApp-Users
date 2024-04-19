namespace Users.Application.Models.Common.DTO ;
using Aplication.Models.Common.DTO;

    public class RecommendationsDTO
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string UserAsociateId { get; set; }
        public Guid TypeOfRecommendationId { get; set; }
        public UserBasicInfo User { get; set; }
        public UserBasicInfo UserAsociate { get; set; }
        public ReferencialTableDTO TypeOfRecommendation { get; set; }
        public Guid EnrollServiceUserId { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
