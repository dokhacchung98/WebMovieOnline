using Common.GenericRepository;
using Infrastructure.Entities;
using System.Collections.Generic;

namespace ApplicationCore.Repositories
{
    public interface IActorRepository : IGenericRepository<Actor>
    {
        ICollection<Actor> SearchActorByName(string actorName);
    }
}