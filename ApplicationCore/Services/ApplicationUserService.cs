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

        public void UpdateUser(ApplicationUser user, object key)
        {
            ApplicationUser currentUser = _repository.GetByID(key);

            // set current propreties not changes
            if (currentUser != null)
            {
                user.UserName = currentUser.UserName;
                user.AccessFailedCount = currentUser.AccessFailedCount;
                user.Avatar = currentUser.Avatar;
                user.EmailConfirmed = currentUser.EmailConfirmed;
                user.LockoutEnabled = currentUser.LockoutEnabled;
                user.LockoutEndDateUtc = currentUser.LockoutEndDateUtc;
                user.PasswordHash = currentUser.PasswordHash;
                user.PhoneNumberConfirmed = currentUser.PhoneNumberConfirmed;
                user.TwoFactorEnabled = currentUser.TwoFactorEnabled;
                user.Wallpaper = currentUser.Wallpaper;
                user.SecurityStamp = currentUser.SecurityStamp;
                user.CreatedDate = currentUser.CreatedDate;
            }

            _repository.Update(user, key);
        }
    }
}