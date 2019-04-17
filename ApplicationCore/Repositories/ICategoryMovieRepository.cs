using Common.GenericRepository;
using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Repositories
{
    public interface ICategoryMovieRepository : IGenericRepository<CategoryMovie>
    {
        ICollection<Guid> GetIdCategoryByMovieId(Guid movieId);

        CategoryMovie FindBy2Id(Guid movieId, Guid modelId);
    }
}
