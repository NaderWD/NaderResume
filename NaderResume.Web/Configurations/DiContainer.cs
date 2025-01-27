using NaderResume.Business.Services.Implementations;
using NaderResume.Business.Services.Interfaces;
using NaderResume.Data.Repositories.Implementations;
using NaderResume.Data.Repositories.Interfaces;

namespace NaderResume.Web.Configurations
{
    public static class DiContainer
    {
        public static void ServicesRegistration(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>(); 
        }
    }
}
