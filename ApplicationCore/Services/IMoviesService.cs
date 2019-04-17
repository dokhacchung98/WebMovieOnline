using Common.Service;
using Infrastructure.Entities;
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
    }
}