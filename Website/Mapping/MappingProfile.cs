using AutoMapper;
using Infrastructure.Entities;
using Infrastructure.Identity;
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
        }

        private void CreateMapFromViewModelsToEntites()
        {
            CreateMap<UpdateUserViewModel, ApplicationUser>();
            CreateMap<NewsViewModel, News>();
            CreateMap<MoviesViewModel, Movie>();
            CreateMap<ActorViewModel, Actor>();
            CreateMap<DirectorViewModel, Director>();
            CreateMap<ProducerViewModel, Producer>();
        }

        private void CreateMapFromEntitiesToViewModels()
        {
            CreateMap<ApplicationUser, UpdateUserViewModel>();
            CreateMap<News, NewsViewModel>();
            CreateMap<Movie, MoviesViewModel>();
            CreateMap<Actor, ActorViewModel>();
            CreateMap<Director, DirectorViewModel>();
            CreateMap<Producer, ProducerViewModel>();
        }
    }
}