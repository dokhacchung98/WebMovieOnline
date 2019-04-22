using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Website.ViewModels;

namespace Website.ViewModel
{
    public class CategorysViewModel : BaseEntityViewModel
    {
        [DisplayName("Tên thể loại")]
        public string NameCategory { get; set; }
    }
}