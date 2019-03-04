using Common.Service;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public interface IRoleService: IEntityService<IdentityRole>
    {
        string GetRoleNameByRoleId(string id);
    }
}
