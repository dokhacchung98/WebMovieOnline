using Common.Service;
using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public interface ICategoryMovieService : IEntityService<CategoryMovie>
    {
        ICollection<Guid> GetIdCategoryByMovieId(Guid movieId);

        CategoryMovie FindBy2Id(Guid movieId, Guid modelId);
    }
}
