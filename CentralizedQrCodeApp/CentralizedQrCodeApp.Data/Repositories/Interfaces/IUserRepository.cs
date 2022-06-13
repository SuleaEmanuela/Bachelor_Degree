using CentralizedQrCodeApp.Data.DataModels;
using CentralizedQrCodeApp.TL.DTOs;
using System.Threading.Tasks;

namespace CentralizedQrCodeApp.Data.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {

        Task<UserRegistrationDto> CreateUserAsync(UserRegistrationDto userDto);

        Task<AuthentificationResponseDto> LoginUserAsync(UserAuthentificationDto userDto);

    }
}
