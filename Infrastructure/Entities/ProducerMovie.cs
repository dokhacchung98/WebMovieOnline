using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities
{
    public class ProducerMovie : BaseEntity
    {
        #region Relation
        [ForeignKey("Producer")]
        public Guid ProducerId { get; set; }
        public Producer Producer { get; set; }

        [ForeignKey("Movie")]
        public Guid MovieId { get; set; }
        public Movie Movie { get; set; }
        #endregion
    }
}