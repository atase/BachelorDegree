using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.DTOs
{
    public class CompatibilityScoreDto
    {
        public int GiverId { get; set; }
        public int ReceiverId { get; set; }
        public int Score { get; set; }
    }
}
