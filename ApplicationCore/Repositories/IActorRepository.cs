using Common.GenericRepository;
using Infrastructure.Entities;

namespace ApplicationCore.Repositories
{
    public interface IActorRepository : ITagRepository<Actor>
    {
    }
}