using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyNeuralNetwork
{
    public class InputNeuron : INeuron
    {
        public double Output { get { return Value; } }
        public double Value { get; set; }

        public double Error { get { return 0; } set { } }

        public INeuron[] CreateNeurons(int count, bool bias)
        {
            INeuron[] neurons = new INeuron[count + (bias ? 1 : 0)];
            for (int i = 0; i < count; i++)
                neurons[i] = new InputNeuron();
            if (bias) neurons[neurons.Length - 1] = new BiasNeuron();

            return neurons;
        }

        public INeuron Initialize(INeuron[] inputNeurons)
        {
            return this;
        }

        public void PushInputs() { }
        public void PassError() { }
        public void CorrectWeights(double learnRate) { }
    }
}
