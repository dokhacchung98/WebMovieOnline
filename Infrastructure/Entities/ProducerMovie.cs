using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Entities
{
    public class ProducerMovie
    {
        #region Relation

        [Key]
        [Column(Order = 1)]
        [ForeignKey("Producer")]
        public Guid ProducerId { get; set; }

        public virtual Producer Producer { get; set; }

        [Key]
        [Column(Order = 2)]
        [ForeignKey("Movie")]
        public Guid MovieId { get; set; }

        public virtual Movie Movie { get; set; }

        #endregion Relation
    }
}