using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities
{
    public class ActorMovie : BaseEntity
    {
        public string Role { get; set; }

        #region Relation
        [ForeignKey("Actor")]
        public Guid ActorId { get; set; }
        public Actor Actor { get; set; }

        [ForeignKey("Movie")]
        public Guid MovieId { get; set; }
        public Movie Movie { get; set; }
        #endregion
    }
}