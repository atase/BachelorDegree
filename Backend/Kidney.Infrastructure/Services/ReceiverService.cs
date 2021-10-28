using Kidney.Core.Entities;
using Kidney.Core.Repositories;
using Kidney.Core.Services;
using Kidney.Infrastructure.Services.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kidney.Infrastructure.Services
{
    public class ReceiverService : Service<Receiver>, IReceiverService
    {
        private IReceiverRepository _receiverRepository;

        public ReceiverService(IReceiverRepository receiverRepository)
        {
            _receiverRepository = receiverRepository;
        }
        public bool Register(Receiver receiver)
        {
            var result = _receiverRepository.Add(receiver).Result;
            if (result == null)
            {
                return false;
            }

            return true;
        }
    }
}
