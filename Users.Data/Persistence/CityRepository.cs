using Users.Aplication.Contracts.Persistence;
using Users.Dominio;

namespace Users.Infraestructure.Persistence
{
    public class CityRepository : RepositoryBase<City>, ICityRepository
    {
        public CityRepository(UsersDbContext context) : base(context)
        {
        }
    }
}
