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
    public class UserInformation : BaseEntity
    {
        [StringLength(255)]
        public string Avatar { get; set; }

        [StringLength(100)]
        public string Address { get; set; }

        [StringLength(12)]
        public string Phone { get; set; }

        public GenderEnum Gender { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Email { get; set; }
    }
}
