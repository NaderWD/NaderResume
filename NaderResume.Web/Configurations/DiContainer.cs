using AutoMapper;
using NaderResume.Business.Services.Implementations;
using NaderResume.Business.Services.Interfaces;
using NaderResume.Data.Profiles;
using NaderResume.Data.Repositories.Implementations;
using NaderResume.Data.Repositories.Interfaces;
using System.Reflection;

namespace NaderResume.Web.Configurations
{
    public static class DiContainer
    {
        public static void ServicesRegistration(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
    }
}
