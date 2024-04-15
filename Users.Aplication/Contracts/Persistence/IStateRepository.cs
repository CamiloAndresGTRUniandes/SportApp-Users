namespace Users.Aplication.Contracts.Persistence ;
using Dominio;

    public interface IStateRepository : IAsyncRepository<State>
    {
        Task<IEnumerable<State>> GetStatesByCountry(Guid countryId);
    }
