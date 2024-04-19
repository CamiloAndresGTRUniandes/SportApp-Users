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

        public async Task<EnrollServiceUser> GetEnrollsByIdAsync(Guid id)
        {
            var result = await _context
                .EnrollServiceUser
                .Include(p => p.Plan)
                .Include(p => p.User)
                .Include(p => p.UserRecommendations)
                .ThenInclude(tp=>tp.TypeOfRecommendation)
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync();

            return result;
        }
    }
