using Common.GenericRepository;
using Infrastructure.DataContext;
using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Repositories
{
    public class TrailerRepository : GenericRepository<Trailer>, ITrailerRepository
    {
        public TrailerRepository(MovieDbContext dbContext) : base(dbContext)
        {
        }

        public object SearchTrailerByName(string name)
        {
            return _dbContext.Trailers.Where(t => t.TrailerName.Contains(name)).ToList();
        }
    }
}
