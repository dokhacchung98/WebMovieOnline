using Common.GenericRepository;
using Infrastructure.DataContext;
using Infrastructure.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Linq;

namespace ApplicationCore.Repositories
{
    public class ApplicationUserRepository : GenericRepository<ApplicationUser>, IApplicationUserRepository
    {
        public ApplicationUserRepository(MovieDbContext dbContext) : base(dbContext)
        {
        }

        public bool AddRoleToUser(string userId, string roleId)
        {
            var userManager = new UserManager<ApplicationUser>
                                (new UserStore<ApplicationUser>(_dbContext));
            var result = userManager.AddToRole(userId, roleId);

            return (result == null) ? false : true;
        }

        public IEnumerable<IdentityRole> GetRolesByUserId(object userId)
        {
            var model = _dbContext.Users.Find(userId);
            IEnumerable<IdentityRole> roles = _dbContext.Roles.ToList()
                .Where(item => model.Roles.FirstOrDefault(r => r.RoleId == item.Id) == null)
                .ToList();
            return roles;
        }
    }
}