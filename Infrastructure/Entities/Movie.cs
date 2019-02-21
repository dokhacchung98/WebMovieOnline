using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities
{
    public class Movie : BaseEntity
    {
        public string Name { get; set; }
        public int IdRating { get; set; }
        public string Description { get; set; }

        #region Relation
        public ICollection<CategoryMovie> CategoryMovies { get; set; }
        #endregion
    }
}
