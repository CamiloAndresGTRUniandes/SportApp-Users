namespace Users.Infraestructure.Persistence ;
using Application.Contracts.Persistence;
using Application.Events;
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

            foreach (var enrrollUser in result)
            {
                if (enrrollUser.Plan.Name.ToLower().Contains("basic") || enrrollUser.EndSuscription is null ||
                    enrrollUser.EndSuscription < DateTime.UtcNow)
                {
                    enrrollUser.WasPayed = false;
                }
                else
                {
                    enrrollUser.WasPayed = true;
                }
            }

            await _context.SaveChangesAsync();
            return result;
        }

        public async Task<bool> UpdateDatesEnrollUser(string userId, DateTime start, DateTime end, PlanEvent planEvent)
        {
            var enrolls = await _context.EnrollServiceUser
                .Where(p => p.UserId == userId)
                .ToListAsync();

            foreach (var enroll in enrolls)
            {
                await SavePlan(planEvent);
                enroll.PlanId = planEvent.Id;
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

        private async Task SavePlan(PlanEvent planEvent)
        {
            var planUpdate = await _context.Plan.Where(p => p.Id == planEvent.Id).FirstOrDefaultAsync();
            if (planUpdate != null)
            {
                planUpdate.Name = planEvent.Name;
                planUpdate.Price = planEvent.Price;
                planUpdate.UpdateBy = "System";
            }
            else
            {
                Plan planCreated = new();
                planCreated.Name = planEvent.Name;
                planCreated.Price = planEvent.Price;
                planCreated.CreatedBy = "System";

                _context.Plan.Add(planCreated);
            }

            await _context.SaveChangesAsync();
        }
    }
