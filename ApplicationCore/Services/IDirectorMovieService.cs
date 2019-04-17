using Common.Service;
using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public interface IDirectorMovieService : IEntityService<DirectorMovie>
    {
        ICollection<Guid> GetIdDirectorByMovieId(Guid movieId);

        DirectorMovie FindBy2Id(Guid movieId, Guid modelId);
    }
}
