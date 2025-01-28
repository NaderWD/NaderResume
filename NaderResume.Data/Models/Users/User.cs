using NaderResume.Data.Models.Common;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NaderResume.Data.Models.Users
{
    public class User : BaseEntity
    {
        [DisplayName("نام")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(150)]
        public string? FirstName { get; set; }

        [DisplayName("نام خانوادگی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(150)]
        public string? LastName { get; set; }

        [DisplayName("ایمیل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [DataType(DataType.EmailAddress)]
        [MaxLength(150)]
        public string? Email { get; set; }

        [DisplayName("تلفن همراه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [DataType(DataType.PhoneNumber)]
        [MaxLength(15)]
        public string? Phone { get; set; }

        [DisplayName("کلمه ی عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [DataType(DataType.Password)]
        [MaxLength(100)]
        public string? Password { get; set; }

        [DisplayName("تکرار کلمه ی عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string? Password2 { get; set; }

        public bool IsActive { get; set; }
    }
}