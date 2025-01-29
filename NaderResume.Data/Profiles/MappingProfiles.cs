using AutoMapper;
using NaderResume.Data.Models.Users;
using NaderResume.Data.ViewModels.UserVM;

namespace NaderResume.Data.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<CreateUserVM, User>().ReverseMap();
            CreateMap<UpdateUserVM, User>().ReverseMap();
        }
    }
}
