namespace Users.Application.Contracts.Persistence ;
using Aplication.Contracts.Persistence;
using Dominio;
using Events;

    public interface IEnrollServiceUserRepository : IAsyncRepository<EnrollServiceUser>
    {
        Task<List<EnrollServiceUser>> GetEnrollsByAsociateAsync(string userAsociateId);
        Task<bool> UpdateDatesEnrollUser(string userId, DateTime start, DateTime end, PlanEvent planEvent);
        Task<EnrollServiceUser> GetEnrollsByIdAsync(Guid id);
    }
