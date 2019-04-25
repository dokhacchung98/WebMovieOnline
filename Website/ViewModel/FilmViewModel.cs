using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Website.ViewModel
{
    public class FilmViewModel
    {
        public FilmViewModel() : base()
        {
            CreatedDate = DateTime.Now;
            Id = Guid.NewGuid();
            if (MovieId == null)
                MovieId = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        [DisplayName("Tập phim")]
        public int Episodes { get; set; }

        [DisplayName("Đường dẫn")]
        public string Link { get; set; }

        public Guid MovieId { get; set; }

        [DisplayName("Ngày tạo")]
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime? CreatedDate { get; set; }
    }
}