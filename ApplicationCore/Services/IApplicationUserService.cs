using Common.Service;
using Infrastructure.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;

namespace ApplicationCore.Services
{
    public interface IApplicationUserService : IEntityService<ApplicationUser>
    {
        IEnumerable<IdentityRole> GetRolesByUserId(object userId);
        bool AddRoleToUser(string userId, string roleId);

        void UpdateUser(ApplicationUser user, object key);
    }
}