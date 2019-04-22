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
    public class ResolutionMovieRepository : GenericRepository<MovieResolution>, IResolutionMovieRepository
    {
        public ResolutionMovieRepository(MovieDbContext dbContext) : base(dbContext)
        {
        }

        public ICollection<Guid> GetIdResolutionByMovieId(Guid movieId)
        {
            return _dbContext.MovieResolutions.Where(t => t.MovieId == movieId).Select(t => t.ResolutionId).ToList();
        }

        public MovieResolution FindBy2Id(Guid movieId, Guid modelId)
        {
            return _dbContext.MovieResolutions.Where(t => t.ResolutionId == modelId && t.MovieId == movieId).FirstOrDefault();
        }
    }
}
