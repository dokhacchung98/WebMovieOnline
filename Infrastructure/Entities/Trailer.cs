using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Entities
{
    public class Trailer : BaseEntity
    {
        public string Link { get; set; }

        #region Relation

        [ForeignKey("Movie")]
        public Guid? MovieID { get; set; }

        public virtual Movie Movie { get; set; }

        #endregion Relation
    }
}