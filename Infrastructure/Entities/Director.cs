using System;
using System.Collections.Generic;

namespace Infrastructure.Entities
{
    public class Director : BaseEntity
    {
        public string NameDirector { get; set; }
        public DateTime Dob { get; set; }
        public int Sex { get; set; }
        public string Description { get; set; }
        public string PathImage { get; set; }

        #region Relation
        public virtual ICollection<Image> Images { get; set; }
        
        public virtual ICollection<Movie> Movies { get; set; }

        #endregion Relation
    }
}