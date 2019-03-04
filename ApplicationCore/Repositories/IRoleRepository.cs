using Common.GenericRepository;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ApplicationCore.Repositories
{
    public interface IRoleRepository : IGenericRepository<IdentityRole>
    {
        string GetRoleNameByRoleId(string id);
    }
}