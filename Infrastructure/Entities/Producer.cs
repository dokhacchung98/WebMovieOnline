using System.Collections.Generic;

namespace Infrastructure.Entities
{
    public class Producer : BaseEntity
    {
        public string NameProducer { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        #region Relation

        public virtual ICollection<ProducerMovie> ProducerMovies { get; set; }

        #endregion Relation
    }
}