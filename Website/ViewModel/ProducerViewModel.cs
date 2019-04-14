using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using Website.ViewModels;

namespace Website.ViewModel
{
    public class ProducerViewModel : BaseEntityViewModel
    {
        [DisplayName("Tên nhà sản xuất")]
        public string NameProducer { get; set; }
    }
}