using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities
{
   public  class Producer : BaseEntity
    {
        public string NameProducer { get; set; }

        #region Relation
        public virtual ICollection<ProducerMovie> ProducerMovies { get; set; }
        #endregion
    }
}