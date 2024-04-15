using Users.Aplication.Contracts.Persistence;
using Users.Dominio;

namespace Users.Infraestructure.Persistence
{
    public class NutrionalProfileRepository : RepositoryBase<NutrionalProfile>, INutrionalProfileRepository
    {
        public NutrionalProfileRepository(UsersDbContext context) : base(context)
        {
        }
    }
}
