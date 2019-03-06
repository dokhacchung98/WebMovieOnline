using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities
{
    public class InformationUser : BaseEntity
    {
        public string NameUser { get; set; }
        public DateTime Dob { get; set; }

        //#region Relation
       // [ForeignKey("User")]
        //public Guid UserId { get; set; }
        //public User User { get; set; }
        //#endregion
    }
}