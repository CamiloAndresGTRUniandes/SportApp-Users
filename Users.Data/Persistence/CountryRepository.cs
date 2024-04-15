using Users.Aplication.Contracts.Persistence;
using Users.Dominio;

namespace Users.Infraestructure.Persistence
{
    public class CountryRepository : RepositoryBase<Country>, ICountryRepository
    {
        public CountryRepository(UsersDbContext context) : base(context)
        {
        }
    }
}
