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
    public class FilmRepository : GenericRepository<Film>, IFilmRepository
    {
        public FilmRepository(MovieDbContext dbContext) : base(dbContext)
        {
        }

        public IList<Film> GetAllFilmInSeriesTV(Guid IdMovie)
        {
            return _dbContext.Films.Where(t => t.MovieId == IdMovie).ToList();
        }

        public Film GetFilmByIdMovie(Guid IdMovie)
        {
            return _dbContext.Films.Where(t => t.MovieId == IdMovie).FirstOrDefault();
        }

        public ICollection<Film> GetFilmsByMovieId(Guid id)
        {
            return _dbContext.Films.Where(t => t.MovieId == id).ToList();
        }
    }
}
