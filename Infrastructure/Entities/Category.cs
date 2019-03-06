using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities
{
    public class Category : BaseEntity
    {
        public string NameCategory { get; set; }
        public string Description { get; set; }

        #region Relation
        public ICollection<CategoryMovie> CategoryMovies { get; set; }
        #endregion
    }
}