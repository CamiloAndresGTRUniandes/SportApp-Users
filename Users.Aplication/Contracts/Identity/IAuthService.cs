namespace Users.Aplication.Contracts.Identity ;
using Models.Identity;

    public interface IAuthService
    {
        Task<AuthResponse> Login(AuthRequest request);
        Task<RegistrationResponse> Register(RegistrationRequest request);
        Task<bool> IsEmailUnique(string email);
    }
