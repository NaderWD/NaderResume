using NaderResume.Business.Services.Interfaces;
using NaderResume.Data.Models.Users;
using NaderResume.Data.Repositories.Interfaces;
using NaderResume.Data.ViewModels.UserVM;

namespace NaderResume.Business.Services.Implementations
{
    public class UserService(IUserRepository repository) : IUserService
    {
        private readonly IUserRepository _repository = repository;


        public async Task<CreateUserResult> CreateUser(CreateUserVM createUser)
        {
            CreateUserVM user = new CreateUserVM()
            {
                FirstName = createUser.FirstName,
                LastName = createUser.LastName,
                Email = createUser.Email,
                Phone = createUser.Phone,
                Password = createUser.Password,
                Password2 = createUser.Password2,
            };
            await _repository.Insert(user);
            await _repository.Save();
            return CreateUserResult.Success;
        }

        public Task DeleteUser(int id)
        {
            _repository.Delete(id);
            return Task.CompletedTask;
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _repository.GetAll();
        }

        public async Task<User> GetUser(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<UpdateUserVM> UpdateUser(int id)
        {
            var user = await _repository.GetById(id);

            if (user == null) return null;

            return new UpdateUserVM()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Phone = user.Phone,
            };
        }
    }
}
