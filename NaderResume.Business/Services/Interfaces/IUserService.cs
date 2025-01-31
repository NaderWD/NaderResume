using NaderResume.Data.Models.Users;
using NaderResume.Data.ViewModels.AccountVM;
using NaderResume.Data.ViewModels.UserVM;

namespace NaderResume.Business.Services.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsers();
        Task<User> GetUser(int id);
        Task<User> GetUserByEmail(string email);
        Task<CreateUserResult> CreateUser(CreateUserVM createUser);
        Task<UpdateUserVM> GetForUpdateUser(int id);
        Task<UpdateUserResult> UpdateUser(UpdateUserVM updateUser);
        Task<FilterUserVM> Filter(FilterUserVM filter);
        Task<LoginResult> LoginUser(LoginVM model);
        void DeleteUser(int id);
    }
}
