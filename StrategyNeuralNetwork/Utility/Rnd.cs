using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyNeuralNetwork
{
    public static class Rnd
    {
        public static System.Random rnd = new System.Random();
        public static double GetRand()
        {
            return rnd.NextDouble() * 2 - 1;
        }
    }
}
