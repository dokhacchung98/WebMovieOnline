using System.Collections.Generic;

namespace Infrastructure.Entities
{
    public class Resolution : BaseEntity
    {
        public string NameResolution { get; set; }

        #region Relation

        public virtual ICollection<MovieResolution> MovieResolutions { get; set; }

        #endregion Relation
    }
}