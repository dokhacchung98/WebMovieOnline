using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Entities
{
    public class Movie : BaseEntity
    {
        public string Name { get; set; }
        public DateTime DatePublish { get; set; }
        public int LengthTime { get; set; }
        public string Language { get; set; }
        public string Country { get; set; }
        public int CountView { get; set; }
        public Boolean IsHot { get; set; }
        public string NameEn { get; set; }
        public int EnableAge { get; set; }

        #region Relation

        public virtual ICollection<DirectorMovie> DirectorMovies { get; set; }
        public virtual ICollection<ActorMovie> ActorMovies { get; set; }
        public virtual ICollection<ProducerMovie> ProducerMovies { get; set; }
        public virtual ICollection<CategoryMovie> CategoryMovies { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
        public virtual ICollection<News> News { get; set; }
        public virtual ICollection<Resolution> Resolutions { get; set; }

        public virtual ICollection<Trailer> Trailers { get; set; }

        public virtual ICollection<TagMovie> TagMovies { get; set; }


        #endregion Relation
    }
}