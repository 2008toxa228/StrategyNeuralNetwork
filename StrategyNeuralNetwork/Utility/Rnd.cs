using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyNeuralNetwork
{
    public static class Rnd
    {
        public static System.Random rnd;

        static Rnd()
        {
            rnd = new System.Random(1);
        }
        public static double GetRand()
        {
            return rnd.NextDouble() * 2 - 1;
        }
    }
}
