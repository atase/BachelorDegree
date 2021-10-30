using Kidney.Core.DTOs;
using Kidney.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kidney.Core.Services
{
    public interface IMatchingService
    {
        public MatchingDataDTO<GiverDTO, ReceiverDTO> Matching();
        public bool Compatible(Giver giver, Receiver receiver);
    }
}
