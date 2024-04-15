namespace Users.Infraestructure.Persistence ;
using Aplication.Contracts.Persistence;
using Dominio;
using Microsoft.EntityFrameworkCore;

    public class StateRepository : RepositoryBase<State>, IStateRepository
    {
        public StateRepository(UsersDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<State>> GetStatesByCountry(Guid countryId)
        {
            return await _context
                .State
                .Where(
                    p =>
                        p.Enabled == true
                        &&
                        p.CountryId == countryId
                ).ToListAsync();
        }
    }
