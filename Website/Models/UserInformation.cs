using Infrastructure.Enum;
using Infrastructure.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Website.Models
{
    public class UserInformation
    {
        [Key, ForeignKey("User")]
        public string UserId { get; set; }

        [StringLength(255)]
        public string Avatar { get; set; }

        [StringLength(100)]
        public string Address { get; set; }

        [StringLength(12)]
        public string Phone { get; set; }

        public GenderEnum Gender { get; set; }

        public DateTime? CreatedDate { get; set; }

        public Guid? CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public Guid? UpdatedBy { get; set; }

        public StatusUserEnum Status { get; set; }

        #region Relation

        public string FirstName { get; set; }

        public virtual ApplicationUser User { get; set; }

        #endregion Relation
    }
}