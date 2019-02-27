using Infrastructure.Enum;
using Infrastructure.Enums;
using Infrastructure.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities
{
    public class UserInformation
    {
        [Key]
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

        public string FirstName { get; set; }
    }
}
