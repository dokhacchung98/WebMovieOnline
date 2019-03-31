using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Website.ViewModels;

namespace Website.ViewModel
{
    public class MoviesViewModel : BaseEntityViewModel
    {
        [DisplayName("Tên phim")]
        public string Name { get; set; }

        [DisplayName("Ngày chiếu")]
        [DataType(DataType.Date)]
        public DateTime DatePublish { get; set; }

        [DisplayName("Độ dài phim")]
        public int LengthTime { get; set; }

        [DisplayName("Ngôn ngữ")]
        public string Language { get; set; }

        [DisplayName("Quốc gia")]
        public string Country { get; set; }
        
        [DisplayName("Phim hot")]
        public Boolean IsHot { get; set; }

        [DisplayName("Tên tiếng Anh")]
        public string NameEn { get; set; }

        [DisplayName("Độ tuổi cho phép")]
        public int EnableAge { get; set; }
    }
}