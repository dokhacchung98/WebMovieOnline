using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using Website.ViewModels;

namespace Website.ViewModel
{
    public class NewsViewModel : BaseEntityViewModel
    {
        [DisplayName("Tiêu Đề")]
        public string Title { get; set; }
        [DisplayName("Mô Tả Ngắn")]
        public string ShortDescription { get; set; }
        [DisplayName("Phim")]
        public Guid? MovieId { get; set; }
    }
}