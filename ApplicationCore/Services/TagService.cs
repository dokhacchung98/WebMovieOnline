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
    public class TagService : EntityService<Tag>, ITagService
    {
        public readonly ITagRepository _repository;
        public TagService(ITagRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public ICollection<Tag> SearchTagByName(string nameTag)
        {
            return _repository.SearchTagByName(nameTag);
        }
    }
}
