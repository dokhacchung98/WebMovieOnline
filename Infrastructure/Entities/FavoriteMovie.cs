using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities
{
    public class FavoriteMovie : BaseEntity
    {
        #region Relation
        [ForeignKey("Favorite")]
        public Guid FavoriteId { get; set; }
        public Favorite Favorite { get; set; }

        [ForeignKey("Movie")]
        public Guid MovieId { get; set; }
        public Movie Movie { get; set; }
        #endregion
    }
}