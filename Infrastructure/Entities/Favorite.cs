using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities
{
    public class Favorite : BaseEntity
    {
        #region Relation
        public ICollection<FavoriteMovie> FavoriteMovies { get; set; }

        //[ForeignKey("User")]
        //public Guid UserId { get; set; }
        //public User User { get; set; }
        #endregion
    }
}