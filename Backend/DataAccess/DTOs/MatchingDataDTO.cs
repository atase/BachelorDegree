
using System.Collections.Generic;


namespace Kidney.DataAccess.DTOs
{
    public class MatchingDataDTO<T, U>
    {
        public List<T> TElements { get; set; }
        public List<U> UElements { get; set; }
        public MatchingDataDTO() { }
          
    }
}
