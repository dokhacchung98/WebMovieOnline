using Infrastructure.Enum;
using System;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Entities
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            Id = Guid.NewGuid();
            CreatedDate = DateTime.Now;
            IsDeleted = false;
            Description = "";
            Thumbnail = "";
        }
        [Key]
        public Guid Id { get; set; }
        public string Description { get; set; }
        public string Thumbnail { get; set; }
        public DateTime? CreatedDate { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public Guid? UpdatedBy { get; set; }
        public StatusEnum Status { get; set; }
        public bool IsDeleted { get; set; }
    }
}
