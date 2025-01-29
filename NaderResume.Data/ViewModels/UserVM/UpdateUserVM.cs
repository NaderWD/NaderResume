using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using NaderResume.Data.Models.Common;

namespace NaderResume.Data.ViewModels.UserVM
{
    public class UpdateUserVM
    {
        public int Id { get; set; }

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
    }

    public enum UpdateUserResult
    {
        Success,
        Error,
        UserNotFounf,
        EmailDuplicated,
        PhoneDuplicated,
    }
}
