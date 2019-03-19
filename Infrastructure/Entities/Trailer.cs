using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities
{
    public class Trailer : BaseEntity
    {
        public string Link { get; set; }

        #region Relation
        [ForeignKey("Movie")]
        public Guid MovieID { get; set; }
        public virtual Movie Movie { get; set; }
        #endregion
    }
}
