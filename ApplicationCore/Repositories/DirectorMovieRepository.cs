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
    public class DirectorMovieRepository : GenericRepository<DirectorMovie>, IDirectorMovieRepository
    {
        public DirectorMovieRepository(MovieDbContext dbContext) : base(dbContext)
        {
        }

        public ICollection<Guid> GetIdDirectorByMovieId(Guid movieId)
        {
            return _dbContext.DirectorMovies.Where(t => t.MovieId == movieId).Select(t => t.DirectorId).ToList();
        }

        public DirectorMovie FindBy2Id(Guid movieId, Guid modelId)
        {
            return _dbContext.DirectorMovies.Where(t => t.DirectorId == modelId && t.MovieId == movieId).FirstOrDefault();
        }
    }
}
