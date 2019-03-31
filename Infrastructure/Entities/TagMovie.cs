using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Entities
{
    public class TagMovie
    {
        [Key]
        [Column(Order = 1)]
        [ForeignKey("Tag")]
        public Guid TagId { get; set; }

        public virtual Tag Tag { get; set; }

        [Key]
        [Column(Order = 2)]
        [ForeignKey("Movie")]
        public Guid MovieId { get; set; }

        public virtual Movie Movie { get; set; }
    }
}