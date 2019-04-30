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
    public class RatingRepository : GenericRepository<Rating>, IRatingRepository
    {
        public RatingRepository(MovieDbContext dbContext) : base(dbContext)
        {
        }

        public Rating Find(Guid IdMovie, string IdUse)
        {
            return _dbContext.Ratings.Where(t => t.MovieId == IdMovie && IdUse.Equals(t.UserId)).FirstOrDefault();
        }

        public ICollection<Rating> GetAllRatingByIdMovie(Guid IdMovie)
        {
            return _dbContext.Ratings.Where(t => t.MovieId == IdMovie).ToList();
        }
    }
}
