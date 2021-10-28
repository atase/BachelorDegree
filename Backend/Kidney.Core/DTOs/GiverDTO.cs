using Kidney.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kidney.Core.DTOs
{
    class GiverDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public List<User> CompatibleReceivers {get; set;}
    }
}
