using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities
{
    public class Director : BaseEntity
    {
        public string NameDirector { get; set; }
        public DateTime Dob { get; set; }
        public int Sex { get; set; }
        public string Description { get; set; }

        #region Relation
        public ICollection<Image> Images { get; set; }
        public ICollection<Movie> Movies { get; set; }
        #endregion
    }
}