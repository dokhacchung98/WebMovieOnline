using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Entities
{
    public class Rating : BaseEntity
    {
        public string Feedback { get; set; }
        public double StarRating { get; set; }

        #region Relation

        [ForeignKey("Movie")]
        public Guid MovieId { get; set; }

        public Movie Movie { get; set; }

        #endregion Relation
    }
}