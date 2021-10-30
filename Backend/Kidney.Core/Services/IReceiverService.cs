using Kidney.Core.Entities;
using Kidney.Infrastructure.Services.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kidney.Core.Services
{
    public interface IReceiverService : IService<Receiver>
    {
        public bool Register(Receiver receiver);
        public Receiver GetInformations(int id);
    }
}
