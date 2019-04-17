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
    public class ResolutionService : EntityService<Resolution>, IResolutionService
    {
        private readonly IResolutionRepository _repository;
        public ResolutionService(IResolutionRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public IEnumerable<Resolution> SearchByName(string keyword)
        {
            return _repository.Search(keyword);
        }
    }
}
