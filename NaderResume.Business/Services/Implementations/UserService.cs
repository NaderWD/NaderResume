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
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            CreateUserVM user = new()
            {
                FirstName = createUser.FirstName,
                LastName = createUser.LastName,
                Email = createUser.Email.Trim().ToLower(),
                Phone = createUser.Phone,
                Password = createUser.Password,
                Password2 = createUser.Password2,
            };

            await _repository.Insert(user);
            await _repository.Save();
            return CreateUserResult.Success;
        }

        public void DeleteUser(int id)
        {
            _repository.Delete(id);
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _repository.GetAll();
        }

        public async Task<User> GetUser(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<UpdateUserVM> GetForUpdateUser(int id)
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

        public async Task<UpdateUserResult> UpdateUser(UpdateUserVM updateUser)
        {
            var user = await _repository.GetById(updateUser.Id);
            if (user == null) return UpdateUserResult.UserNotFound;

#pragma warning disable CS8604 // Possible null reference argument.
            if (await _repository.DuplicatedPhone(user.Id, updateUser.Phone))
                return UpdateUserResult.PhoneDuplicated;

#pragma warning disable CS8602 // Dereference of a possibly null reference.
            if (await _repository.DuplicatedEmail(user.Id, updateUser.Email.ToLower().Trim()))
                return UpdateUserResult.EmailDuplicated;

            user.FirstName = updateUser.FirstName;
            user.LastName = updateUser.LastName;
            user.Email = updateUser.Email;
            user.Phone = updateUser.Phone;

            _repository.Update(updateUser);
            await _repository.Save();

            return UpdateUserResult.Success;
        }

        public async Task<FilterUserVM> Filter(FilterUserVM filter)
        {
            return await _repository.Filter(filter);
        }
    }
}
