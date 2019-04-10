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
    public class CategorysService : EntityService<Category>, ICategorysService
    {
        public readonly ICategorysRepository _repository;

        public CategorysService(ICategorysRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public ICollection<Category> SearchCategoryByName(string nameCategory)
        {
            return _repository.SearchCategoryByName(nameCategory);
        }
    }
}
