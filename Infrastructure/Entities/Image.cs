using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Entities
{
    public class Image : BaseEntity
    {
        public string Value { get; set; }
        public DateTime DatePublish { get; set; }

        #region Relation

        [ForeignKey("Director")]
        public Guid DicrectorId { get; set; }

        public virtual Director Director { get; set; }

        [ForeignKey("Movie")]
        public Guid MovieId { get; set; }

        public virtual Movie Movie { get; set; }

        [ForeignKey("Actor")]
        public Guid ActorId { get; set; }

        public virtual Actor Actor { get; set; }

        [ForeignKey("News")]
        public Guid NewsId { get; set; }

        public virtual News News { get; set; }

        #endregion Relation
    }
}