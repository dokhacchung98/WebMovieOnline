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
    public class CategoryMovieRepository : GenericRepository<CategoryMovie>, ICategoryMovieRepository
    {
        public CategoryMovieRepository(MovieDbContext dbContext) : base(dbContext)
        {
        }

        public ICollection<Guid> GetIdCategoryByMovieId(Guid movieId)
        {
            return _dbContext.GetCategoryMovies.Where(t => t.MovieId == movieId).Select(t => t.CategoryId).ToList();
        }

        public CategoryMovie FindBy2Id(Guid movieId, Guid modelId)
        {
            return _dbContext.GetCategoryMovies.Where(t => t.CategoryId == modelId && t.MovieId == movieId).FirstOrDefault();
        }
    }
}
