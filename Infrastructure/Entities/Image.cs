using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Entities
{
    public class Image : BaseEntity
    {
        public string Value { get; set; }
        public DateTime DatePublish { get; set; }

    
    }
}