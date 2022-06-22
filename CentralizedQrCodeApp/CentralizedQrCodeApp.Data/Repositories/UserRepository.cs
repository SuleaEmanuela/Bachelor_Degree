using CentralizedQrCodeApp.Data.AutoMapper;
using CentralizedQrCodeApp.Data.DataModels;
using CentralizedQrCodeApp.Data.Extensions;
using CentralizedQrCodeApp.Data.Repositories.Interfaces;
using CentralizedQrCodeApp.TL.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;

namespace CentralizedQrCodeApp.Data.Repositories
{

    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly AuthetificationHandler _authetificationHandler;


        public UserRepository(UserManager<User> userManager, QrCodeContext _umContext, IConfiguration configuration) : base(_umContext)

        {
            _userManager = userManager;
            
            _authetificationHandler = new AuthetificationHandler(configuration);
        }

        public async Task<IdentityResult> CreateUserAsync(UserRegistrationDto userDto)
        {
            User userToCreate = Mapping.Mapper.Map<User>(userDto);

            var userResult = await _userManager.CreateAsync(userToCreate, userDto.Password);

           // UserRegistrationDto userCreated = Mapping.Mapper.Map<UserRegistrationDto>(result);
            return userResult;

        }

        public async Task<AuthentificationResponseDto> LoginUserAsync(UserAuthentificationDto userAuthentification)
        {
            var user = await _userManager.FindByNameAsync(userAuthentification.Email);

            if (user == null || !await _userManager.CheckPasswordAsync(user, userAuthentification.Password))
                return (new AuthentificationResponseDto { ErrorMessage = "Invalid Authentication" });

            var signingCredentials = _authetificationHandler.GetSigningCredentials();

            var claims = _authetificationHandler.GetClaims(user);

            var tokenOptions = _authetificationHandler.GenerateTokenOptions(signingCredentials, claims);

            var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return (new AuthentificationResponseDto
            {
                IsAuthSuccessful = true,
                Token = token 
            });
        }


    }
}
