using Infrastructure.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Entities
{
    public class FavoriteMovie
    {
        #region Relation

        [Key]
        [Column(Order = 1)]
        [ForeignKey("User")]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        [Key]
        [Column(Order = 2)]
        [ForeignKey("Movie")]
        public Guid MovieId { get; set; }

        public virtual Movie Movie { get; set; }

        #endregion Relation
    }
}