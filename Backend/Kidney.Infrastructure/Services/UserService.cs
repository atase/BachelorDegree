using Kidney.Core.Entities;
using Kidney.Core.Repositories;
using Kidney.Core.Repositories.Base;
using Kidney.Infrastructure.Data;
using Kidney.Infrastructure.Services.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kidney.Infrastructure.Services
{
    public class UserService : Service<User>, IUserService
    {
        private IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        public bool Register(User user) 
        {
            var result = _userRepository.Add(user).Result;
            if (result == null)
            {
                return false;
            }

            return true;
        }

    }
}
