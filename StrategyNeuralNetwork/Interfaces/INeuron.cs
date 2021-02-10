using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyNeuralNetwork
{
    public interface INeuron
    {
        double Output { get; }
        double Value { get; set; }
        double Error { get; set; }
        INeuron Initialize(INeuron[] inputNeurons);
        void PushInputs();
        void PassError();
        void CorrectWeights(double learnRate);
    }
}
