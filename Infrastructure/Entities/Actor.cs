using System;
using System.Collections.Generic;

namespace Infrastructure.Entities
{
    public class Actor : BaseEntity
    {
        public string NameActor { get; set; }
        public DateTime Dob { get; set; }
        public int IdCountry { get; set; }
        public int Sex { get; set; }
        public int Tus { get; set; }
        public string PathImage { get; set; }

        #region Relation

        public virtual ICollection<ActorMovie> ActorMovies { get; set; }

        #endregion
        public virtual ICollection<Image> Images { get; set; }

        #endregion Relation
    }
}