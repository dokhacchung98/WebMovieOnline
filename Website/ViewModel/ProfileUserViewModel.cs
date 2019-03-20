using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website.ViewModel
{
    public class ProfileUserViewModel
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Avatar { get; set; }
        public string Wallpaper { get; set; }
    }
}