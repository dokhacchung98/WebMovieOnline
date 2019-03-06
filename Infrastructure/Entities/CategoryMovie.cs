using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities
{
    public class CategoryMovie : BaseEntity
    {
        #region Relation
        [ForeignKey("Category")]
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }

        [ForeignKey("Movie")]
        public Guid MovieId { get; set; }
        public Movie Movie { get; set; }
        #endregion
    }
}