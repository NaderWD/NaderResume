﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NaderResume.Data.Context;
using NaderResume.Data.Models.Users;
using NaderResume.Data.Repositories.Interfaces;
using NaderResume.Data.ViewModels.UserVM;

namespace NaderResume.Data.Repositories.Implementations
{
    public class UserRepository(ResumeContext context, IMapper mapper) : IUserRepository
    {
        private readonly ResumeContext _context = context;
        private readonly IMapper _mapper = mapper;


        public void Delete(int Id)
        {
            _context.Remove(Id);
        }

        public async Task<User> GetById(int Id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == Id);
        }

        public async Task<User> GetByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(e => e.Email == email);
        }

        public async Task<List<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task Insert(CreateUserVM model)
        {
            var user = _mapper.Map<User>(model);
            await _context.Users.AddAsync(user);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(UpdateUserVM model)
        {
            var user = _mapper.Map<User>(model);
            _context.Users.Update(user);
        }

        public async Task<bool> DuplicatedEmail(int id, string email)
        {
            return await _context.Users.AnyAsync(u => u.Email == email && u.Id != id);
        }

        public async Task<bool> DuplicatedPhone(int id, string phone)
        {
            return await _context.Users.AnyAsync(u => u.Phone == phone && u.Id != id);
        }

        public async Task<FilterUserVM> Filter(FilterUserVM filter)
        {
            var query = _context.Users.AsQueryable();

            if (!string.IsNullOrEmpty(filter.FirstName))
            { query = query.Where(u => u.FirstName == filter.FirstName); }

            if (!string.IsNullOrEmpty(filter.LastName))
            { query = query.Where(u => u.LastName == filter.LastName); }

            if (!string.IsNullOrEmpty(filter.Email))
            { query = query.Where(u => u.Email == filter.Email); }

            if (!string.IsNullOrEmpty(filter.Phone))
            { query = query.Where(u => u.Phone == filter.Phone); }

            await filter.Paging(query.Select(user => new DetailsUserVM()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Phone = user.Phone,
                CreateDate = DateTime.Now,
                IsActive = user.IsActive,
            }));

            return filter;
        }
    }
}
