using System.Collections.Generic;
using ApplicationCore.Repositories;
using Common.Service;
using Infrastructure.Entities;

namespace ApplicationCore.Services
{
    public class MoviesService : EntityService<Movie>, IMoviesService
    {
        private readonly IMoviesRepository _repository;

        public MoviesService(IMoviesRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public ICollection<Movie> GetAllFeatureMovie()
        {
            return _repository.GetAllFeatureMovies();
        }

        public ICollection<Movie> GetAllSeriesTV()
        {
            return _repository.GetAllSeriesTV();
        }

        /*public ICollection<Movie> GetMovieHotByNumber(int countMovie)
        {
            return _repository.GetMovieHotByNumber(countMovie);
            //xong
        }
        */
        
        public ICollection<Movie> SearchFeatureMovieByName(string name)
        {
            return _repository.SearchMovieByNameAndType(name, false);
        }

        public ICollection<Movie> SearchMovieByName(string name)
        {
            return _repository.SearchMovieByName(name);
        }

        public ICollection<Movie> SearchSeriesTVByName(string name)
        {
            return _repository.SearchMovieByNameAndType(name, true);
        }
    }
}