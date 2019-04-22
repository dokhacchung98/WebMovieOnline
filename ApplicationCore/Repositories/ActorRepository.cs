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

        public ICollection<Actor> SearchActorByName(string actorName)
        {
            IQueryable<Actor> list = this._dbContext.Actors
                                        .Where(actor => actor.NameActor.Contains(actorName));

            return list.ToList();
        }
    }
}
