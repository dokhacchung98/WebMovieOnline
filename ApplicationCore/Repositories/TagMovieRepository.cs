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
    public class TagMovieRepository : GenericRepository<TagMovie>, ITagMovieRepository
    {
        public TagMovieRepository(MovieDbContext dbContext) : base(dbContext)
        {
        }

        public ICollection<Guid> GetIdTagByMovieId(Guid movieId)
        {
            return _dbContext.TagMovies.Where(t => t.MovieId == movieId).Select(t => t.TagId).ToList();
        }

        public TagMovie FindBy2Id(Guid movieId, Guid modelId)
        {
            return _dbContext.TagMovies.Where(t => t.TagId == modelId && t.MovieId == movieId).FirstOrDefault();
        }
    }
}
