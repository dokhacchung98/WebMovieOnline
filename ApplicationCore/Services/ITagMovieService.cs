using Common.Service;
using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public interface ITagMovieService : IEntityService<TagMovie>
    {
        ICollection<Guid> GetIdTagByMovieId(Guid movieId);

        TagMovie FindBy2Id(Guid movieId, Guid modelId);
    }
}
