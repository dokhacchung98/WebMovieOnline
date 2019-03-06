using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities
{
    public class Movie : BaseEntity
    {
        public string Name { get; set; }
        public DateTime DatePublish { get; set; }
        public int IdCountry { get; set; }
        public string Description { get; set; }
        public DateTime LengthTime { get; set; }
        public string Language { get; set; }
        public string Country { get; set; }
        public int CountView { get; set; }
        public int IsHot { get; set; }
        public string nameEn { get; set; }
        public int enableAge { get; set; }

        #region Relation
        public ICollection<Director> Directors { get; set; }
        public ICollection<Image> Images { get; set; }
        public ICollection<ActorMovie> ActorMovies { get; set; }
        public ICollection<Film> Films { get; set; }
        public ICollection<ProducerMovie> ProducerMovies { get; set; }
        public ICollection<CategoryMovie> CategoryMovies { get; set; }
        public ICollection<Rating> Ratings { get; set; }

        /// <summary>
        ///  Quality xem lại
        /// </summary>

        //[ForeignKey("Trailer")]
        //public Guid TrailerId { get; set; }
        //public Trailer Trailer { get; set; }

        [ForeignKey("Tag")]
        public Guid TagId { get; set; }
        public Tag Tag { get; set; }

        [ForeignKey("Resolution")]
        public Guid ResolutionId { get; set; }
        public Resolution Resolution { get; set; }

        #endregion
    }
}