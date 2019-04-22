using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using Website.ViewModels;

namespace Website.ViewModel
{
    public class TagViewModel : BaseEntityViewModel
    {
        [DisplayName("Tên Tag")]
        public string NameTag { get; set; }
    }
}