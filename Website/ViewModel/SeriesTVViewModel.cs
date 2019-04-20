using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website.ViewModel
{
    public class SeriesTVViewModel
    {
        public MoviesViewModel MoviesViewModel { get; set; }
        public IList<FilmViewModel> FilmViewModels { get; set; }
    }
}