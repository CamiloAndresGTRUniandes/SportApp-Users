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

        public async Task<bool> UpdateDatesEnrollUser(PlanEnrolledEvent @event)
        {
            await SavePlan(@event.Plan);
            await SaveEnroll(@event);
            await SaveSuscription(@event);
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

        private async Task SaveEnroll(PlanEnrolledEvent @event)
        {
            var enrolls = await _context.EnrollServiceUser
                .Where(p => p.UserId == @event.UserId)
                .ToListAsync();

            foreach (var enroll in enrolls)
            {
                enroll.PlanId = @event.Plan.Id;
                enroll.StartSuscription = @event.StartDate;
                enroll.EndSuscription = @event.EndDate;
            }
            await _context.SaveChangesAsync();
        }


        private async Task SaveSuscription(PlanEnrolledEvent @event)
        {
            var suscriptionUpdate = await _context.SuscriptionUser
                .Where(p => p.SubscriptionId == @event.SubscriptionId)
                .FirstOrDefaultAsync();

            if (suscriptionUpdate != null)
            {
                suscriptionUpdate.SubscriptionId = @event.SubscriptionId;
                suscriptionUpdate.EndDate = @event.EndDate;
                suscriptionUpdate.StartDate = @event.EndDate;
                suscriptionUpdate.PlanId = @event.Plan.Id;
                suscriptionUpdate.UpdateBy = "System";
            }
            else
            {
                var suscriptionCreated = new SuscriptionUser();
                suscriptionCreated.SubscriptionId = @event.SubscriptionId;
                suscriptionCreated.EndDate = @event.EndDate;
                suscriptionCreated.StartDate = @event.EndDate;
                suscriptionCreated.PlanId = @event.Plan.Id;
                suscriptionCreated.UserId = @event.UserId;
                suscriptionCreated.CreatedBy = "System";
                _context.SuscriptionUser.Add(suscriptionCreated);
            }
            await _context.SaveChangesAsync();
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
