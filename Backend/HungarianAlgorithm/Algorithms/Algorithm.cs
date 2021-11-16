using System;
using System.Collections.Generic;
using System.Text;

namespace HungarianAlgorithm.Algorithms
{
    public interface Algorithm
    {
        
        int[,] Compatible { get; set; }
       
        int MatchingSize { get; set; }
        int GiversNo { get; set; }
        int ReceiversNo { get; set; }
        void Compute();
    }
}
