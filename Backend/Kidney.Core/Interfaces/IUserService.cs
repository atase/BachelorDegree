using Kidney.Core.Entities;
using Kidney.Infrastructure.Services.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kidney.Infrastructure.Services
{
    public interface IUserService : IService<User>
    {
        public bool Register(User user);
    }
}
