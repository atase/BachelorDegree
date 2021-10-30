using Kidney.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kidney.Core.DTOs
{
    public class ReceiverDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public List<GiverDTO> CompatibleGivers { get; set; }
    }
}
