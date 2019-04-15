using Common.GenericRepository;
using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Repositories
{
    public interface IResolutionRepository : IGenericRepository<Resolution>
    {
        IEnumerable<Resolution> Search(string keyword);
    }
}
