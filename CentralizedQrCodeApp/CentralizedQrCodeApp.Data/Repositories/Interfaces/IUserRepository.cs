using CentralizedQrCodeApp.Data.DataModels;
using CentralizedQrCodeApp.TL.DTOs;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace CentralizedQrCodeApp.Data.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {

        Task<IdentityResult> CreateUserAsync(UserRegistrationDto userDto);

        Task<AuthentificationResponseDto> LoginUserAsync(UserAuthentificationDto userDto);

    }
}
