using System.Collections.Generic;

namespace Infrastructure.Entities
{
    public class News : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string PathImage { get; set; }

        #region Relation

        public virtual ICollection<Image> Images { get; set; }

        #endregion Relation
    }
}