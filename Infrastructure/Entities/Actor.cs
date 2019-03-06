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
        public DateTime Dob { get; set; }
        public int IdCountry { get; set; }
        public int Sex { get; set; }
        public int Tus { get; set; }

        #region Relation
        public ICollection<ActorMovie> ActorMovies { get; set; }
        public ICollection<Image> Images { get; set; }
        #endregion
    }
}