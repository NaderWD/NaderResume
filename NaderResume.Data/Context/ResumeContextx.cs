using Microsoft.EntityFrameworkCore;
using NaderResume.Data.Models.Users;

namespace NaderResume.Data.Context
{
    public class ResumeContextx : DbContext
    {
        public ResumeContextx(DbContextOptions<ResumeContextx> option) : base(option)
        {

        }
        public DbSet<User> Users { get; set; }
    }
}

