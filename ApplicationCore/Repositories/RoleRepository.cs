using Common.GenericRepository;
using Infrastructure.DataContext;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Repositories
{
    public class RoleRepository: GenericRepository<IdentityRole>, IRoleRepository
    {
        public RoleRepository(MovieDbContext db) : base(db)
        {

        }

        public string GetRoleNameByRoleId(string id)
        {
            var model = _dbContext.Roles.Find(id);
            if(model == null)
            {
                return null;
            }
            return model.Id;
        }
    }
}
