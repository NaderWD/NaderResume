using NaderResume.Data.Models.Users;
using NaderResume.Data.ViewModels.UserVM;

namespace NaderResume.Business.Services.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsers();
        Task<User> GetUser(int id);
        Task<CreateUserResult> CreateUser(CreateUserVM createUser);
        Task<UpdateUserVM> GetForUpdateUser(int id);
        Task<UpdateUserResult> UpdateUser(UpdateUserVM updateUser);
        void DeleteUser(int id);
    }
}
