using Users.Aplication.Contracts.Persistence;
using Users.Dominio;

namespace Users.Infraestructure.Persistence
{
    public class GoalRepository : RepositoryBase<Goal>, IGoalRepository
    {
        public GoalRepository(UsersDbContext context) : base(context)
        {
        }
    }
}
