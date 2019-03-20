using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities
{
    public class News : BaseEntity
    {
        public string Title { get; set; }
        public string ShortDescription { get; set; }

        #region Relation
        [ForeignKey("Movie")]
        public Guid MovieId { get; set; }
        public virtual Movie Movie { get; set; }
        #endregion
    }
}