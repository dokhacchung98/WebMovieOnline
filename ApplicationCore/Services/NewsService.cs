using ApplicationCore.Repositories;
using Common.GenericRepository;
using Common.Service;
using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class NewsService : EntityService<News>, INewsService
    {
        private readonly INewsRepository _repository;
        public NewsService(INewsRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public IEnumerable<News> GetNumberOfListNews(int number)
        {
            return _repository.GetListNews(number);
        }
    }
}
