using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyNeuralNetwork
{
    public interface INetwork
    {
        int[] CountInLayers { get; }
        void SetInputs(double[] inputs);
        void FeedForward();
        double[] GetOutputs();
        double GetSquareError(double[] target);
        double Train(DataSet dataSet, double learnRate);
    }
}
