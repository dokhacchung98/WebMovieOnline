using Common.GenericRepository;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ApplicationCore.Repositories
{
    public interface IRoleRepository : IEntityService<IdentityRole>
    {
        string GetRoleNameByRoleId(string id);
    }
}