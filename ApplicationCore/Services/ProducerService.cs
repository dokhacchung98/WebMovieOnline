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
    public class ProducerService : EntityService<Producer>, IProducerService
    {
        private readonly IProducerRepository _repository;
        public ProducerService(IProducerRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
