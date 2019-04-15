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
    public class DirectorMovieRepository : GenericRepository<DirectorMovie>, IDirectorMovieRepository
    {
        public DirectorMovieRepository(MovieDbContext dbContext) : base(dbContext)
        {
        }
    }
}
