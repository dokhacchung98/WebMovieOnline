using System.Collections.Generic;

namespace Infrastructure.Entities
{
    public class Tag : BaseEntity
    {
        public string NameTag { get; set; }

        #region Relation

        public virtual ICollection<Movie> Movies { get; set; }

        #endregion Relation
    }
}