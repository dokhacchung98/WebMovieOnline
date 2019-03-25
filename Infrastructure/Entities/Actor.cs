using System.Collections.Generic;

namespace Infrastructure.Entities
{
    public class Actor : BaseEntity
    {
        public string NameActor { get; set; }

        #region Relation

        public virtual ICollection<ActorMovie> ActorMovies { get; set; }

        #endregion Relation
    }
}