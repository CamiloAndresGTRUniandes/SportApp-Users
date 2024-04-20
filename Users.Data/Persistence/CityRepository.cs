namespace Users.Infraestructure.Persistence ;
using Aplication.Contracts.Persistence;
using Dominio;

    public class CityRepository : RepositoryBase<City>, ICityRepository
    {
        public CityRepository(UsersDbContext context) : base(context)
        {
        }
    }
