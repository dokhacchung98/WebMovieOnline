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
    public class ActorsService : EntityService<Actor>, IActorsService
    {
        private readonly IActorRepository _repository;
        public ActorsService(IActorRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public ICollection<Actor> SearchActorByName(string actorName)
        {
            return this._repository.SearchActorByName(actorName);
        }
    }
}
