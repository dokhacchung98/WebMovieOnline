﻿using Common.GenericRepository;
using Infrastructure.Entities;
using System;
using System.Collections.Generic;

namespace ApplicationCore.Repositories
{
    public interface IMoviesRepository : IGenericRepository<Movie>
    {
        ICollection<Movie> GetAllFeatureMovies();

        ICollection<Movie> GetAllSeriesTV();

        ICollection<Movie> SearchMovieByName(string name);

        ICollection<Movie> SearchMovieByNameAndType(string name, bool isSeriesTV);

        ICollection<Movie> GetCountMovieHot(int countMovie);

        ICollection<Movie> GetAllMovieHot();

        ICollection<Movie> GetCountFeatureFilm(int countMovie);

        ICollection<Movie> GetCountSeriesMovies(int countMovie);

        ICollection<Movie> GetNewestMovies(int countMovie);

        ICollection<Movie> SearchMoviesByKeyWord(string keyword);

        ICollection<Movie> GetMoviesByCategoryId(Guid id);
    }
}