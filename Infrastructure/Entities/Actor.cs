using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities
{
    public class Actor : BaseEntity
    {
        public string NameActor { get; set; }
        #region Relation
        public virtual ICollection<ActorMovie> ActorMovies { get; set; }
        #endregion
    }
}