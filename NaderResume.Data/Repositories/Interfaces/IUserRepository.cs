using NaderResume.Data.Models.Users;
using NaderResume.Data.ViewModels.UserVM;

namespace NaderResume.Data.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAll();
        Task<User> GetById(int Id);
        Task Insert(CreateUserVM model);
        Task Update(UpdateUserVM model);
        Task Delete(int Id);
        Task Save();
    }
}
