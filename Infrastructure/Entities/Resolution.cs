using System.Collections.Generic;

namespace Infrastructure.Entities
{
    public class Resolution : BaseEntity
    {
        public string NameResolution { get; set; }

        #region Relation

        public virtual ICollection<Movie> Movies { get; set; }

        #endregion Relation
    }
}