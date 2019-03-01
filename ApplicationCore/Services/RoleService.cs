using ApplicationCore.Repositories;
using Common.Service;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ApplicationCore.Services
{
    public class RoleService : EntityService<IdentityRole>, IRoleService
    {
        private readonly IRoleRepository _repository;

        public RoleService(IRoleRepository roleRepository) : base(roleRepository)
        {
            _repository = roleRepository;
        }
    }
}