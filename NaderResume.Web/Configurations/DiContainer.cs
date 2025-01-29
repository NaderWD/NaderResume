using AutoMapper;
using NaderResume.Business.Services.Implementations;
using NaderResume.Business.Services.Interfaces;
using NaderResume.Data.Profiles;
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

        public static void MappingConfiguration(this IServiceCollection services)
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfiles>());
            IMapper mapper = config.CreateMapper();
        }
    }
}
