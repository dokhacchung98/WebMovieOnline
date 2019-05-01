using Common.Service;
using Infrastructure.Entities;
using System;
using System.Collections.Generic;

namespace ApplicationCore.Services
{
    public interface IMoviesService : IEntityService<Movie>
    {
        ICollection<Movie> GetAllFeatureMovie();

        ICollection<Movie> GetAllSeriesTV();

        ICollection<Movie> SearchMovieByName(string name);

        ICollection<Movie> SearchFeatureMovieByName(string name);

        ICollection<Movie> SearchSeriesTVByName(string name);

        ICollection<Movie> GetCountMovieHot(int countMovie);

        ICollection<Movie> GetAllMovieHot();

        ICollection<Movie> GetCountFeatureFilm(int countMovie);

        ICollection<Movie> GetCountSeriesMovies(int countMovie);

        ICollection<Movie> GetNewestMovies(int countMovie);

        ICollection<Movie> SearchMoviesByKeyWord(string keyword);

        ICollection<Movie> GetMoviesByCategoryId(Guid id);
    }
}