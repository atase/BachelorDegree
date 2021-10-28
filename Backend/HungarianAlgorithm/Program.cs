using HungarianAlgorithm.Algorithms;
using System;

namespace HungarianAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            Algorithm algorithm = new HungarianAlgorithmImpl();
            algorithm.Start();
        }
    }
}
