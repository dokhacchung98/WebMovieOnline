using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities
{
    public class Tag : BaseEntity
    {
        public string NameTag { get; set; }

        #region Relation
        public virtual ICollection<Movie> Movies { get; set; }
        #endregion
    }
}
