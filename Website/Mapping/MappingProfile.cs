using AutoMapper;
using Infrastructure.Entities;
using Infrastructure.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Website.Models;
using Website.ViewModel;

namespace Website.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMapFromEntitiesToViewModels();
            CreateMapFromViewModelsToEntites();

            CreateMap<News, NewsViewModel>();
            CreateMap<NewsViewModel, News>();
        }

        private void CreateMapFromViewModelsToEntites()
        {
            CreateMap<UpdateUserViewModel, ApplicationUser>();
        }

        private void CreateMapFromEntitiesToViewModels()
        {
            CreateMap<ApplicationUser, UpdateUserViewModel>();
        }
    }
}