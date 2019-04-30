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
            CreateMap<ResolutionViewModel, Resolution>();
            CreateMap<TagViewModel, Tag>();
            CreateMap<CategorysViewModel, Category>();
            CreateMap<ProducerViewModel, Producer>();
            CreateMap<FilmViewModel, Film>();
            CreateMap<TrailerViewModel, Trailer>();
            CreateMap<RatingViewModel, Rating>();
        }

        private void CreateMapFromEntitiesToViewModels()
        {
            CreateMap<ApplicationUser, UpdateUserViewModel>();
            CreateMap<News, NewsViewModel>();
            CreateMap<Movie, MoviesViewModel>();
            CreateMap<Actor, ActorViewModel>();
            CreateMap<Director, DirectorViewModel>();
            CreateMap<Resolution, ResolutionViewModel>();
            CreateMap<Tag, TagViewModel>();
            CreateMap<Category, CategorysViewModel>();
            CreateMap<Producer, ProducerViewModel>();
            CreateMap<Film, FilmViewModel>();
            CreateMap<Trailer, TrailerViewModel>();
            CreateMap<Rating, RatingViewModel>();
        }
    }
}