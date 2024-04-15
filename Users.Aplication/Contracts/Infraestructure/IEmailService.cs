using Users.Aplication.Models;

namespace Users.Aplication.Contracts.Infraestructure
{
    public interface IEmailService
    {
        Task<bool> SendEmail(Email email);
    }
}
