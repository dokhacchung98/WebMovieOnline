using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using Website.ViewModels;

namespace Website.ViewModel
{
    public class ActorViewModel: BaseEntityViewModel
    {
        [DisplayName("Tên diễn viên")]
        public string NameActor { get; set; }
    }
}