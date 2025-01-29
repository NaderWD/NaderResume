using Microsoft.EntityFrameworkCore;
using NaderResume.Data.Context;
using NaderResume.Data.Models.Users;
using NaderResume.Data.Repositories.Interfaces;
using NaderResume.Data.ViewModels.UserVM;

namespace NaderResume.Data.Repositories.Implementations
{
    public class UserRepository(ResumeContext context) : IUserRepository
    {
        private readonly ResumeContext _context = context;

        public Task Delete(int Id)
        {
            _context.Remove(Id);
            return Task.CompletedTask;
        }

        public async Task<User> GetById(int Id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == Id);
        }

        public async Task<List<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task Insert(CreateUserVM model)
        {
            await _context.AddAsync(model);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public Task Update(UpdateUserVM model)
        {
            _context.Update(model);
            return Task.CompletedTask;
        }
    }
}
