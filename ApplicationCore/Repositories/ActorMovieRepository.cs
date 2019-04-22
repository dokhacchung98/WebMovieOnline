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
    public class ActorMovieRepository : GenericRepository<ActorMovie>, IActorMovieRepository
    {
        public ActorMovieRepository(MovieDbContext dbContext) : base(dbContext)
        {
        }

        public ActorMovie FindBy2Id(Guid movieId, Guid modelId)
        {
            return _dbContext.ActorMovies.Where(t => t.ActorId == modelId && t.MovieId == movieId).FirstOrDefault();
        }

        public ICollection<Guid> GetIdActorByMovieId(Guid movieId)
        {
            return _dbContext.ActorMovies.Where(t => t.MovieId == movieId).Select(t => t.ActorId).ToList();
        }
    }
}
