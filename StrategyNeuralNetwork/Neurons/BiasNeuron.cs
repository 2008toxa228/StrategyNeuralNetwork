using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyNeuralNetwork
{
    public class BiasNeuron : INeuron
    {
        public double Output { get { return 1; } }
        public double Value { get { return 1; } set { } }
        public double Error { get { return 0; } set { } }

        public void CorrectWeights(double learnRate) { }
        public INeuron Initialize(INeuron[] inputNeurons) { return this; }
        public void PassError() { }
        public void PushInputs() { }
    }
}
