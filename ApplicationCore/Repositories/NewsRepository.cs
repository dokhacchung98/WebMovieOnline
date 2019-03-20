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
    public class NewsRepository : GenericRepository<News>, INewsRepository
    {
        public NewsRepository(MovieDbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<News> GetListNews(int number)
        {
            return _dbContext.News.ToList().OrderBy(t => t.CreatedBy).Take(number);
        }
    }
}
