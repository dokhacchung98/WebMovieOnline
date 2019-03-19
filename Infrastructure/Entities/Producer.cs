using System.Collections.Generic;

namespace Infrastructure.Entities
{
    public class Producer : BaseEntity
    {
        public string NameProducer { get; set; }

        #region Relation

        public virtual ICollection<ProducerMovie> ProducerMovies { get; set; }

        #endregion Relation
    }
}