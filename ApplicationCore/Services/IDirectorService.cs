using Common.Service;
using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public interface IDirectorService : IEntityService<Director>
    {
        IEnumerable<Director> Search(string keywork);
    }
}
