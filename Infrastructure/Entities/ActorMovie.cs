using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Entities
{
    public class ActorMovie
    {
        public string Role { get; set; }

        #region Relation

        [Key]
        [Column(Order = 1)]
        [ForeignKey("Actor")]
        public Guid ActorId { get; set; }

        public virtual Actor Actor { get; set; }

        [Key]
        [Column(Order = 2)]
        [ForeignKey("Movie")]
        public Guid MovieId { get; set; }

        public virtual Movie Movie { get; set; }

        #endregion Relation
    }
}