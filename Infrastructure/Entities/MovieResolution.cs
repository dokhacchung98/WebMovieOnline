using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities
{
    public class MovieResolution
    {
        #region Relation

        [Key]
        [Column(Order = 1)]
        [ForeignKey("Resolution")]
        public Guid ProducerId { get; set; }
        public virtual Resolution Resolution { get; set; }

        [Key]
        [Column(Order = 2)]
        [ForeignKey("Movie")]
        public Guid MovieId { get; set; }
        public virtual Movie Movie { get; set; }

        #endregion Relation
    }
}
