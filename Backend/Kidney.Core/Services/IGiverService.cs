using Kidney.Core.Entities;
using Kidney.Infrastructure.Services.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kidney.Core.Services
{
    public interface IGiverService : IService<Receiver>
    {
        public bool Register(Giver giver);
    }
}
