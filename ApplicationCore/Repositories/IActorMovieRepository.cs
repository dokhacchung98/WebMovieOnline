using Common.GenericRepository;
using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Repositories
{
    public interface IActorMovieRepository : IGenericRepository<ActorMovie>
    {
        ICollection<Guid> GetIdActorByMovieId(Guid movieId);

        ActorMovie FindBy2Id(Guid movieId, Guid modelId);
    }
}
