using CentralizedQrCodeApp.Data.Extensions;
using CentralizedQrCodeApp.Data.Repositories;
using CentralizedQrCodeApp.Data.Repositories.Interfaces;
using CentralizedQrCodeApp.Service.Services;
using CentralizedQrCodeApp.Service.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;


namespace CentralizedQrCodeApp.Extentions
{
    /// <summary>
    /// Class used to store entity extension methods.
    /// </summary>
    public static class EntityExtensions
    {
        /// <summary>
        /// Configures entity services between repository and repository interfaces.
        /// Configures entity services between service and service interfaces.
        /// </summary>
        /// <param name="services">The service collection needed by entities.</param>
        public static void ConfigureEntityService(this IServiceCollection services)
        {
            services.AddScoped<AuthetificationHandler>();
            services.AddTransient<IQrCodeRepository, QrCodeRepository>();
            services.AddTransient<IQrCodeService, QrCodeService>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserService, UserService>();
        }
    }
}
