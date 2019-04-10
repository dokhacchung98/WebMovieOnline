using Common.GenericRepository;
using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Repositories
{
    public interface ITagRepository : IGenericRepository<Tag>
    {
        ICollection<Tag> SearchTagByName(string nameTag);
    }
}
