using AutoMapper;
using Infrastructure.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Website.Models;

namespace Website.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMapFromEntitiesToViewModels();
            CreateMapFromViewModelsToEntites();
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