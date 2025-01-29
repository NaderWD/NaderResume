using Microsoft.EntityFrameworkCore;
using NaderResume.Data.Models.Users;

namespace NaderResume.Data.Context
{
    public class ResumeContext : DbContext
    {
        public ResumeContext(DbContextOptions<ResumeContext> option) : base(option)
        {

        }
        public DbSet<User> Users { get; set; }
    }
}

