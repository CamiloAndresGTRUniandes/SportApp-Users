namespace Users.Infraestructure.Persistence ;
using Aplication.Contracts.Persistence;
using Dominio;

    public class GoalRepository : RepositoryBase<Goal>, IGoalRepository
    {
        public GoalRepository(UsersDbContext context) : base(context)
        {
        }
    }
