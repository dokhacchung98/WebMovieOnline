using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities
{
    public class Film : BaseEntity
    {
        public string NameFilm { get; set; }
        public string Link { get; set; }

        #region Relation
        [ForeignKey("Movie")]
        public Guid MovieId { get; set; }
        public virtual Movie Movie { get; set; }
        #endregion
    }
}
