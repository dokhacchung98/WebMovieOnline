using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Entities
{
    public class Movie : BaseEntity
    {
        public Movie() : base()
        {
            if (DatePublish == null)
            {
                DatePublish = DateTime.Now;
            }
            IsHot = false;
            if (Language == null)
                Language = "En";
        }

        public string Name { get; set; }
        public DateTime DatePublish { get; set; }
        public int LengthTime { get; set; }
        public string Language { get; set; }
        public string Country { get; set; }
        //Number of count user view
        public int CountView { get; set; }
        public Boolean IsHot { get; set; }
        public string NameEn { get; set; }
        //Minimum of age to view
        public int EnableAge { get; set; }
        //this is Series if value is true
        public Boolean IsSeriesMovie { get; set; }
        //number of epsode movie
        public int Episodes { get; set; }

        #region Relation

        public virtual ICollection<DirectorMovie> DirectorMovies { get; set; }
        public virtual ICollection<ActorMovie> ActorMovies { get; set; }
        public virtual ICollection<ProducerMovie> ProducerMovies { get; set; }
        public virtual ICollection<CategoryMovie> CategoryMovies { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
        public virtual ICollection<News> News { get; set; }
        public virtual ICollection<MovieResolution> MovieResolutions { get; set; }

        public virtual ICollection<Trailer> Trailers { get; set; }

        public virtual ICollection<TagMovie> TagMovies { get; set; }


        #endregion Relation
    }
}