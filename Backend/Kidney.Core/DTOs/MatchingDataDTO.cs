using System;
using System.Collections.Generic;
using System.Text;

namespace Kidney.Core.DTOs
{
    public class MatchingDataDTO<T, U>
    {
        public List<T> TElements { get; set; }
        public List<U> UElements { get; set; }
        public List<CompatiblePairDTO<T, U>> CompatiblePairs { get; set; }

        public MatchingDataDTO() { }
          
    }
}
