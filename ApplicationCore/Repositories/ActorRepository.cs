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
    public class ActorRepository : GenericRepository<Actor>, IActorRepository
    {
        public ActorRepository(MovieDbContext dbContext) : base(dbContext)
        {
        }
    }
}
