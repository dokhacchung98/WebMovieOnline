using Common.GenericRepository;
using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Repositories
{
    public interface IDirectorRepository : IGenericRepository<Director>
    {
        IEnumerable<Director> Search(string keyword);
    }
}
