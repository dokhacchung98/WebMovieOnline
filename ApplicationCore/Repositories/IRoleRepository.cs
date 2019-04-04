using Common.GenericRepository;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ApplicationCore.Repositories
{
    public interface IRoleRepository : ITagRepository<IdentityRole>
    {
        string GetRoleNameByRoleId(string id);
    }
}