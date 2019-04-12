using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using Website.ViewModels;

namespace Website.ViewModel
{
    public class FilmViewModel : BaseEntityViewModel
    {
        [DisplayName("Tập phim")]
        public int Episodes { get; set; }
        [DisplayName("Tên diễn viên")]
        public string Link { get; set; }
    }
}