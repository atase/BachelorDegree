using Kidney.Core.Entities;
using Kidney.Core.Repositories;
using Kidney.Core.Services;
using Kidney.Infrastructure.Services.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kidney.Infrastructure.Services
{
    public class GiverService : Service<Giver>, IGiverService
    {
        private IGiverRepository _giverRepository;

        public GiverService(IGiverRepository giverRepository) 
        {
            _giverRepository = giverRepository;
        }

        public bool Register(Giver giver)
        {
            var result = _giverRepository.Add(giver).Result;
            if (result == null)
            {
                return false;
            }

            return true;
        }
    }
}
