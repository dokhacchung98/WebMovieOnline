using Common.Service;
using Infrastructure.Entities;
using System.Collections.Generic;

namespace ApplicationCore.Services
{
    public interface INewsService : IEntityService<News>
    {
        IEnumerable<News> GetNumberOfListNews(int number);
        IEnumerable<News> SearchNewsByTitle(string value);
        IEnumerable<News> GetCountNews(int count);
    }
}