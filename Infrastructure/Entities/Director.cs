using System;
using System.Collections.Generic;

namespace Infrastructure.Entities
{
    public class Director : BaseEntity
    {
        public string NameDirector { get; set; }
        #region Relation
        
        public virtual ICollection<Movie> Movies { get; set; }

        #endregion Relation
    }
}