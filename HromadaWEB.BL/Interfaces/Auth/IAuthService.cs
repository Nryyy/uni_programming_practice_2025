namespace HromadaWEB.Infrastructure.Interfaces.Auth
{
    public interface IAuthService
    {
        Task<string?> RegisterAsync(RegistrationDto request);
        Task<string?> LoginAsync(LoginDto request);
    }
}
