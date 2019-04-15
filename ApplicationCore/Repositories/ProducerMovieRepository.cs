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
    public class ProducerMovieRepository : GenericRepository<ProducerMovie>, IProducerMovieRepository
    {
        public ProducerMovieRepository(MovieDbContext dbContext) : base(dbContext)
        {
        }
    }
}
