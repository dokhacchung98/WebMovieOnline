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
    public class ProducerMovieRepository : GenericRepository<ProducerMovie>, IProducerMovieRepository
    {
        public ProducerMovieRepository(MovieDbContext dbContext) : base(dbContext)
        {
        }

        public ICollection<Guid> GetIdProducerByMovieId(Guid movieId)
        {
            return _dbContext.ProducerMovies.Where(t => t.MovieId == movieId).Select(t => t.ProducerId).ToList();
        }

        public ProducerMovie FindBy2Id(Guid movieId, Guid modelId)
        {
            return _dbContext.ProducerMovies.Where(t => t.ProducerId == modelId && t.MovieId == movieId).FirstOrDefault();
        }
    }
}
