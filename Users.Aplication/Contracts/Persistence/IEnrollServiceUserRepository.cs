namespace Users.Application.Contracts.Persistence ;
using Aplication.Contracts.Persistence;
using Dominio;

    public interface IEnrollServiceUserRepository : IAsyncRepository<EnrollServiceUser>
    {
        Task<List<EnrollServiceUser>> GetEnrollsByAsociateAsync(string userAsociateId);
        Task<bool> UpdateDatesEnrollUser(string userId, DateTime start, DateTime end, Guid planId);
        Task<EnrollServiceUser> GetEnrollsByIdAsync(Guid id);
    }
