using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using NaderResume.Data.ViewModels.Common;

namespace NaderResume.Data.ViewModels.UserVM
{
    public class FilterUserVM : BasePaging<DetailsUserVM>
    {
        [DisplayName("نام")]
        public string? FirstName { get; set; }

        [DisplayName("نام خانوادگی")]
        public string? LastName { get; set; }

        [DisplayName("ایمیل")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [DisplayName("تلفن همراه")]
        [DataType(DataType.PhoneNumber)]
        public string? Phone { get; set; }
    }
}
