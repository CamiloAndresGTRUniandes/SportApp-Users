namespace Users.Aplication.Contracts.Infraestructure ;
using Models;

    public interface IEmailService
    {
        Task<bool> SendEmail(Email email);
    }
