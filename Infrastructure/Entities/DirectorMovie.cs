using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Entities
{
    public class DirectorMovie
    {
        #region Relation

        [Key]
        [Column(Order = 1)]
        [ForeignKey("Director")]
        public Guid DirectorId { get; set; }

        public virtual Director Director { get; set; }

        [Key]
        [Column(Order = 2)]
        [ForeignKey("Movie")]
        public Guid MovieId { get; set; }

        public virtual Movie Movie { get; set; }

        #endregion Relation
    }
}