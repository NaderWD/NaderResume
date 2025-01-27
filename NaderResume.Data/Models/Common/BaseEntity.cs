using System.ComponentModel.DataAnnotations;

namespace NaderResume.Data.Models.Common
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
    }
}
