﻿using NaderResume.Data.Models.Users;
using NaderResume.Data.ViewModels.UserVM;

namespace NaderResume.Data.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAll();
        Task<User> GetById(int id);
        Task<User> GetByEmail(string email);
        Task Insert(CreateUserVM model);
        void Update(UpdateUserVM model);
        Task<bool> DuplicatedEmail(int id, string email);
        Task<bool> DuplicatedPhone(int id, string phone);
        Task<FilterUserVM> Filter(FilterUserVM filter);
        void Delete(int Id);
        Task Save();
    }
}
