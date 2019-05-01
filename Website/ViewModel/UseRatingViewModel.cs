using Infrastructure.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website.ViewModel
{
    public class UseRatingViewModel
    {
        public RatingViewModel RatingViewModel { get; set; }

        public ApplicationUser UseViewModel { get; set; }
    }
}