using System.Collections.Generic;
using ApplicationCore.Repositories;
using Common.Service;
using Infrastructure.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ApplicationCore.Services
{
    public class ApplicationUserService : EntityService<ApplicationUser>, IApplicationUserService
    {
        private readonly IApplicationUserRepository _repository;

        public ApplicationUserService(IApplicationUserRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public bool AddRoleToUser(string userId, string roleId)
        {
            return _repository.AddRoleToUser(userId, roleId);
        }

        public IEnumerable<IdentityRole> GetRolesByUserId(object userId)
        {
            return _repository.GetRolesByUserId(userId);
        }


    }
}