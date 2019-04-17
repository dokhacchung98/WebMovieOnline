using Common.Service;
using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public interface IActorMovieService : IEntityService<ActorMovie>
    {
        ICollection<Guid> GetIdActorByMovieId(Guid movieId);

        ActorMovie FindBy2Id(Guid movieId, Guid modelId);
    }
}
