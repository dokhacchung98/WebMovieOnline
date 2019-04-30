using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Website.ViewModel
{
    public class RatingViewModel
    {
        [DisplayName("Nội Dung")]
        public string Feedback { get; set; }
        [DisplayName("Sao")]
        public double StarRating { get; set; }

        [Key]
        [Column(Order = 1)]
        public Guid MovieId { get; set; }

        [Key]
        [Column(Order = 2)]
        public string UserId { get; set; }

    }
}