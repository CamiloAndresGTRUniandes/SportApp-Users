namespace Users.Infraestructure.Persistence ;
using Application.Contracts.Persistence;
using Dominio;
using Microsoft.EntityFrameworkCore;

    public class UserRecomendationRepository : RepositoryBase<UserRecommendation>, IUserRecomendationRepository
    {
        public UserRecomendationRepository(UsersDbContext context) : base(context)
        {
        }

        public async Task<List<UserRecommendation>> GetUserNotificationByAsociateAsync(string userAsociateId)
        {
            return await _context
                .UserRecommendation
                .Include(p => p.User)
                .Include(p => p.UserAsociate)
                .Include(p => p.TypeOfRecommendation)
                .Include(p => p.EnrollServiceUser)
                .ThenInclude(p => p.Plan)
                .Where(p => p.UserAsociateId == userAsociateId)
                .ToListAsync();
        }


        public async Task<UserRecommendation> GetUserNotificationByIdAsync(Guid id)
        {
            return await _context
                .UserRecommendation
                .Include(p => p.User)
                .Include(p => p.UserAsociate)
                .Include(p => p.TypeOfRecommendation)
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<List<UserRecommendation>> GetUserNotificationByUserAsync(string userId, Guid type)
        {
            return await _context
                .UserRecommendation
                .Include(p => p.User)
                .Include(p => p.UserAsociate)
                .Include(p => p.TypeOfRecommendation)
                .Where(p => p.UserId == userId && p.TypeOfRecommendationId == type)
                .ToListAsync();
        }
    }
