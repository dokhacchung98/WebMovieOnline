using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Website.ViewModels
{
    public class BaseEntityViewModel
    {
        public BaseEntityViewModel()
        {
            Id = Guid.NewGuid();
            CreatedDate = DateTime.Now;
            Thumbnail = "";
            Description = "";
        }

        [Key]
        public Guid Id { get; set; }
        [DisplayName("Hình Ảnh")]
        public string Thumbnail { get; set; }
        [DisplayName("Mô Tả Chi Tiết")]
        public string Description { get; set; }
        [DisplayName("Ngày tạo")]
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime? CreatedDate { get; set; }
    }
}