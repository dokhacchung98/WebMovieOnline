using Common.GenericRepository;
using Infrastructure.DataContext;
using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Repositories
{
    public class MoviesRepository : GenericRepository<Movie>, IMoviesRepository
    {
        public MoviesRepository(MovieDbContext dbContext) : base(dbContext)
        {
        }

        public ICollection<Movie> GetAllFeatureMovies()
        {
            return _dbContext.Movies.Where(t => t.IsSeriesMovie == false).ToList();
        }

        public ICollection<Movie> GetAllSeriesTV()
        {
            return _dbContext.Movies.Where(t => t.IsSeriesMovie == true).ToList();
        }

        public ICollection<Movie> GetCountMovieHot(int countMovie)
        {
            return _dbContext.Movies.Where(t => t.IsHot == true).OrderBy(t => t.CreatedDate).Take(countMovie).ToList();
        }

        public ICollection<Movie> SearchMovieByName(string name)
        {
            return _dbContext.Movies.Where(t => t.Name.Contains(name)).ToList();
        }

        public ICollection<Movie> SearchMovieByNameAndType(string name, bool isSeriesTV)
        {
            return _dbContext.Movies.Where(t => t.Name.Contains(name) && t.IsSeriesMovie == isSeriesTV).ToList();
        }
    }
}
