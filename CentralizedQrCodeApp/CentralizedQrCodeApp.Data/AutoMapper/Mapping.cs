using AutoMapper;
using System;


namespace CentralizedQrCodeApp.Data.AutoMapper
{
    public static class Mapping
    {
        private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                // This line ensures that internal properties are also mapped over.
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                cfg.AddProfile<MappingProfile>();
            });
            IMapper mapper = config.CreateMapper();
            return mapper;
        });

        public static IMapper Mapper => Lazy.Value;
    }
}
