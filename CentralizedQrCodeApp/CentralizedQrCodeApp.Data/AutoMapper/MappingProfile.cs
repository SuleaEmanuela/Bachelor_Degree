using AutoMapper;
using CentralizedQrCodeApp.Data.DataModels;
using CentralizedQrCodeApp.TL.DTOs;
using Microsoft.AspNetCore.Identity;

namespace CentralizedQrCodeApp.Data.AutoMapper
{
   public  class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<QrCode, QrCodeDto>();
            CreateMap<QrCodeDto, QrCode>();

            CreateMap<UserRegistrationDto, User>()
                .ForMember(u => u.UserName,opt => opt.MapFrom(x => x.Email));
            CreateMap<User,UserRegistrationDto>();
            CreateMap<IdentityResult, UserRegistrationDto>();
            CreateMap< UserRegistrationDto, IdentityResult>();

        }
    }
}
