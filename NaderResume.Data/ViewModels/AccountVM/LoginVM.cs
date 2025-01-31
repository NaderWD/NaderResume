using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace NaderResume.Data.ViewModels.AccountVM
{
    public class LoginVM
    {
        [DisplayName("ایمیل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [DataType(DataType.EmailAddress)]
        [MaxLength(150)]
        public string? Email { get; set; }

        [DisplayName("کلمه ی عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [DataType(DataType.Password)]
        [MaxLength(100)]
        public string? Password { get; set; }
    }

    public enum LoginResult
    {
        Success,
        Error,
        UserNotFound
    }
}
