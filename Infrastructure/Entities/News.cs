using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Entities
{
    public class News : BaseEntity
    {
        public string Title { get; set; }
        public string ShortDescription { get; set; }

        #region Relation

        [ForeignKey("Movie")]
        public Guid? MovieId { get; set; }

        public virtual Movie Movie { get; set; }

        #endregion Relation
    }
}