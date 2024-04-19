namespace Users.Application.Contracts.Persistence ;
using Aplication.Contracts.Persistence;
using Dominio;

    public interface IEnrollServiceUserRepository : IAsyncRepository<EnrollServiceUser>
    {
        Task<List<EnrollServiceUser>> GetEnrollsByAsociateAsync(string userAsociateId);
        Task<EnrollServiceUser> GetEnrollsByIdAsync(Guid id);
    }
