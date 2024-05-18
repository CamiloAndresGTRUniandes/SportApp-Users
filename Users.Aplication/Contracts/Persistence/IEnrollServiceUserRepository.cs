namespace Users.Application.Contracts.Persistence ;
using Aplication.Contracts.Persistence;
using Dominio;
using Events;

    public interface IEnrollServiceUserRepository : IAsyncRepository<EnrollServiceUser>
    {
        Task<List<EnrollServiceUser>> GetEnrollsByAsociateAsync(string userAsociateId);
        Task<bool> UpdateDatesEnrollUser(PlanEnrolledEvent @event);
        Task<EnrollServiceUser> GetEnrollsByIdAsync(Guid id);
    }
