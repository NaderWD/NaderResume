using NaderResume.Data.Models.Common;

namespace NaderResume.Data.Models.Users
{
    public class User : BaseEntity
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Password { get; set; }
        public string? Password2 { get; set; }
        public bool IsActive { get; set; }
    }
}