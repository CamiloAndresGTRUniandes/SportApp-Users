namespace Users.Infraestructure.Persistence ;
using Application.Contracts.Persistence;
using Dominio;
using Microsoft.EntityFrameworkCore;

    public class EnrollServiceUserRepository : RepositoryBase<EnrollServiceUser>, IEnrollServiceUserRepository
    {
        public EnrollServiceUserRepository(UsersDbContext context) : base(context)
        {
        }

        public async Task<List<EnrollServiceUser>> GetEnrollsByAsociateAsync(string userAsociateId)
        {
            var result = await _context
                .EnrollServiceUser
                .Include(p => p.Plan)
                .Include(p => p.User)
                .Where(p => p.UserAsociateId == userAsociateId)
                .Include(p => p.UserRecommendations)
                .ThenInclude(tp => tp.TypeOfRecommendation)
                .ToListAsync();

            return result;
        }

        public async Task<bool> UpdateDatesEnrollUser(string userId, DateTime start, DateTime end, Guid planId)
        {
            var enrolls = await _context.EnrollServiceUser
                .Where(p => p.UserId == userId)
                .ToListAsync();

            foreach (var enroll in enrolls)
            {
                enroll.PlanId = planId;
                enroll.StartSuscription = start;
                enroll.EndSuscription = end;
            }
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<EnrollServiceUser> GetEnrollsByIdAsync(Guid id)
        {
            var result = await _context
                .EnrollServiceUser
                .Include(p => p.Plan)
                .Include(p => p.User)
                .Include(p => p.UserRecommendations)
                .ThenInclude(tp => tp.TypeOfRecommendation)
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync();

            return result;
        }
    }
