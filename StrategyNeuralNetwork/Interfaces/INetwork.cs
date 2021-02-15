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
        void ProcessData();
        double[] GetOutputs();
        double Train(DataSet dataSet, double learnRate);
        double GetSquareError(double[] target);
    }
}
