using System.Collections.Generic;

namespace Infrastructure.Entities
{
    public class News : BaseEntity
    {
        public string Description { get; set; }

        #region Relation

        public virtual ICollection<Image> Images { get; set; }

        #endregion Relation
    }
}