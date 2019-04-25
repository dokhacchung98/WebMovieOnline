using Common.GenericRepository;
using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Repositories
{
    public interface INewsRepository : IGenericRepository<News>
    {
        /* Get number of items on list news for generate slidebar */
        IEnumerable<News> GetListNews(int number);

        IEnumerable<News> SearchNewsByTitle(string value);
    }
}
