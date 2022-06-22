using CentralizedQrCodeApp.Data.AutoMapper;
using CentralizedQrCodeApp.Data.DataModels;
using CentralizedQrCodeApp.Data.Extensions;
using CentralizedQrCodeApp.Data.Repositories.Interfaces;
using CentralizedQrCodeApp.Service.Services.Interfaces;
using CentralizedQrCodeApp.TL.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CentralizedQrCodeApp.Service.Services
{


    public class UserService : IUserService
    {
        
        private readonly IUserRepository _userRepository;
        
       
        

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
     
            
          
        }

       

        public async Task<AuthentificationResponseDto> LoginAccountAsync (UserAuthentificationDto userForRegistration)
        {
            var result = await _userRepository.LoginUserAsync(userForRegistration);
            return result;
        }

        

        public async Task<IdentityResult> PostAccountAsync(UserRegistrationDto userForRegistration)
        {
            if (userForRegistration == null)
                throw new NullReferenceException("The provided parameter is empty. ");

             return await _userRepository.CreateUserAsync(userForRegistration);
            
        }

    }
}
