using System.Collections.Generic;

namespace Infrastructure.Entities
{
    public class Category : BaseEntity
    {
        public string NameCategory { get; set; }

        #region Relation

        public virtual ICollection<CategoryMovie> CategoryMovies { get; set; }

        #endregion Relation
    }
}