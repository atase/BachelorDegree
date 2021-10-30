using System;
using System.Collections.Generic;
using System.Text;

namespace HungarianAlgorithm.Algorithms
{
    public interface Algorithm
    {
        public int[,] Compatible { get; set; }
        void Start();
    }
}
