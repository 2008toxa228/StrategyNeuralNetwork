using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyNeuralNetwork
{
    public interface ILayer
    {
        INeuron[] Neurons { get; }
    }
}
