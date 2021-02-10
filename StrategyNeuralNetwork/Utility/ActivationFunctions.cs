using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyNeuralNetwork
{
    public delegate double ActFunc(double x, bool isDerevative = false);
    public static class ActivationFunctions
    {
        public static double Sigmoid(double x, bool isDerevative)
        {
            x = 1 / (1 + Math.Pow(Math.E, -x));
            if (isDerevative) { return x * (1 - x); }
            else { return x; }
        }
        public static double FixedReLu(double x, bool isDerevative)
        {
            double k = 0.2;
            if (!isDerevative)
            {
                if (x > 1) { x = k * x + 1 - k; }
                else if (x < 0) { x = k * x; }
            }
            else
            {
                if (x > 1 || x < 0) { x = k; }
                else { x = 1; }
            }
            return x;
        }
        public static double LeackedReLu(double x, bool isDerevative)
        {
            double k = 0.1;
            if (!isDerevative)
            {
                if (x < 0) { x = k * x; }
            }
            else
            {
                if (x < 0) { x = k; }
                else { x = 1; }
            }
            return x;
        }
        public static double Step(double x, bool isDerevative)
        {
            double k = 0.5;
            if (!isDerevative)
            {
                if (x >= 0.5) { x = 1; }
                else { x = 0; }
            }
            else { x = k; }
            return x;
        }
    }
}
