using System;
using System.ComponentModel;
using Website.ViewModels;

namespace Website.ViewModel
{
    public class TrailerViewModel : BaseEntityViewModel
    {
        [DisplayName("Link phim")]
        public string Link { get; set; }

        [DisplayName("Tên Trailer")]
        public string TrailerName { get; set; }

        public Guid MovieId { get; set; }

        [DisplayName("Tên phim")]
        public MoviesViewModel MoviesViewModel { get; set; }
    }
}