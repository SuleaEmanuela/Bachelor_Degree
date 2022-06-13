using CentralizedQrCodeApp.TL.DTOs;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace CentralizedQrCodeApp.Service.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserRegistrationDto> PostAccountAsync(UserRegistrationDto userForRegistration);
        Task<AuthentificationResponseDto> LoginAccountAsync(UserAuthentificationDto userForAuthentification);
    }
}
