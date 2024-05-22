namespace Users.Application.Contracts.Persistence ;
using Aplication.Contracts.Persistence;
using Dominio;

    public interface IUserRecomendationRepository : IAsyncRepository<UserRecommendation>
    {
        Task<List<UserRecommendation>> GetUserNotificationByUserAsync(string userId, Guid type);
        Task<List<UserRecommendation>> GetUserNotificationByAsociateAsync(string userAsociateId);
        Task<UserRecommendation> GetUserNotificationByIdAsync(Guid id);
    }
