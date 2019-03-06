using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        #endregion
    }
}
