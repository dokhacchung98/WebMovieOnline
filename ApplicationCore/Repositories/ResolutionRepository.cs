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
    public class ResolutionRepository : GenericRepository<Resolution> , IResolutionRepository
    {
        public ResolutionRepository(MovieDbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<Resolution> Search(string keyword)
        {
            return _dbContext.Resolutions.Where(t => t.NameResolution.Contains(keyword)).ToList();
        }
    }
}
