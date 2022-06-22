using AutoMapper;
using CentralizedQrCodeApp.Data.DataModels;
using CentralizedQrCodeApp.TL.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using CentralizedQrCodeApp.Data.AutoMapper;
using System.Linq;
using System.Threading.Tasks;
using CentralizedQrCodeApp.Extentions;
using System.IdentityModel.Tokens.Jwt;
using CentralizedQrCodeApp.Service.Services.Interfaces;

namespace CentralizedQrCodeApp.Controllers
{
    [Route("api/accounts")]
   [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IUserService _userService;
       
        public AccountsController(IUserService userService)
        {
            _userService = userService;
           
        }

        [HttpPost("Registration")]
        public async Task<IActionResult> RegisterUser([FromBody] UserRegistrationDto userForRegistration)
        {
            if (userForRegistration == null || !ModelState.IsValid)
                return BadRequest();

            var result = await _userService.PostAccountAsync(userForRegistration);
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);

                return BadRequest(new RegistrationResponseDto { Errors = errors });
            }

            return StatusCode(201);
        }


        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UserAuthentificationDto userForAuthentification)
        { 
            var result = await _userService.LoginAccountAsync(userForAuthentification);
            return Ok(result);
        }
    }
}
