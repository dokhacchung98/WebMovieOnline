using Common.Service;
using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public interface IProducerMovieService : IEntityService<ProducerMovie>
    {
        ICollection<Guid> GetIdProducerByMovieId(Guid movieId);

        ProducerMovie FindBy2Id(Guid movieId, Guid modelId);
    }
}
