namespace Users.Infraestructure.Persistence ;
using Aplication.Contracts.Persistence;
using Dominio;

    public class CountryRepository : RepositoryBase<Country>, ICountryRepository
    {
        public CountryRepository(UsersDbContext context) : base(context)
        {
        }
    }
