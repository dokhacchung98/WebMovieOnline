using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities
{
    public class News : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string PathImage { get; set; }

        #region Relation
        public virtual ICollection<Image> Images { get; set; }
        #endregion
    }
}