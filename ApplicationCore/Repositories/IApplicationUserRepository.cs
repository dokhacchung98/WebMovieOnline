using Common.GenericRepository;
using Infrastructure.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections;
using System.Collections.Generic;

namespace ApplicationCore.Repositories
{
    public interface IApplicationUserRepository : ITagRepository<ApplicationUser>
    {
        IEnumerable<IdentityRole> GetRolesByUserId(object userId);

        bool AddRoleToUser(string userId, string roleId);

        ApplicationUser GetUserFromUserName(string userName);
    }
}