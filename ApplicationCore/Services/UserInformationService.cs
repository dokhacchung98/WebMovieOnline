using ApplicationCore.Repositories;
using Common.Service;
using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class UserInformationService : EntityService<UserInformation>, IUserInformationService
    {
        private readonly IUserInformationRepository repository;
        public UserInformationService(IUserInformationRepository userRepository): base(userRepository)
        {
            repository = userRepository;
        }
    }
}
