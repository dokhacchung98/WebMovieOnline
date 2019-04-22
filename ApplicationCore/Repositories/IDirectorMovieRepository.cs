using Common.GenericRepository;
using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Repositories
{
    public interface IDirectorMovieRepository : IGenericRepository<DirectorMovie>
    {
        ICollection<Guid> GetIdDirectorByMovieId(Guid movieId);

        DirectorMovie FindBy2Id(Guid movieId, Guid modelId);
    }
}
