using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities
{
    public class Resolution : BaseEntity
    {
        public string NameResolution { get; set; }

        #region Relation
        public ICollection<Movie> Movies { get; set; }
        #endregion
    }
}
