namespace Users.Application.Features.EnrollServiceUsers.Queries.GetEnrollRecomendationById;
using Models.Common.DTO;
    public class GetEnrollRecomendationsByIdResult : EnrollServiceUserDTO
    {
        public List<RecommendationsDTO> UserRecommendations { get; set; }
    }
