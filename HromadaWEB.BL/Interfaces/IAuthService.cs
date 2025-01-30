using HromadaWEB.Models.DTOs;
using HromadaWEB.Models.Entities;

namespace HromadaWEB.BL.Interfaces
{
    public interface IAuthService
    {
        Task<string?> RegisterAsync(RegistrationDto request);
        Task<string?> LoginAsync(LoginDto request);
    }
}
