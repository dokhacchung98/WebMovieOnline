using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using Website.ViewModels;

namespace Website.ViewModel
{
    public class DirectorViewModel : BaseEntityViewModel
    {
        [DisplayName("Tên đạo diễn")]
        public string NameDirector { get; set; }
    }
}