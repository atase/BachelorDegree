using System;
using System.Collections.Generic;
using System.Text;

namespace Kidney.Core.DTOs
{
    public class CompatiblePairDTO<T, U>
    {
        public T First { get; set; }
        public U Second { get; set; }

        public CompatiblePairDTO()
        {

        }
        public CompatiblePairDTO(T first, U second)
        {
            this.First = first;
            this.Second = second;
        }
    }
}
