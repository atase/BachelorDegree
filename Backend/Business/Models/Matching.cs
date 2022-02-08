using Kidney.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Models
{
    public class Matching
    {
        public int MatchingValue { get; set; }
        public IEnumerable<Pair<Pair<Giver, Receiver>, int>> OptimalAssigment { get; set; }

    }
}
