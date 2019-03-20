using Infrastructure.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Entities
{
    public class Rating
    {
        public string Feedback { get; set; }
        public double StarRating { get; set; }

        #region Relation
        [Key]
        [Column(Order = 1)]
        [ForeignKey("Movie")]
        public Guid MovieId { get; set; }
        public Movie Movie { get; set; }
        
        [Key]
        [Column(Order = 2)]
        [ForeignKey ("User")]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        #endregion Relation
    }
}