using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Entities
{
    public class Film : BaseEntity
    {
        public string NameFilm { get; set; }
        public string Link { get; set; }

        #region Relation

        [ForeignKey("Movie")]
        public Guid MovieId { get; set; }
        public virtual Movie Movie { get; set; }

        #endregion Relation
    }
}