using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using Website.ViewModels;

namespace Website.ViewModel
{
    public class ResolutionViewModel : BaseEntityViewModel
    {
        [DisplayName("Độ Phân Giải")]
        public string NameResolution { get; set; }
    }
}