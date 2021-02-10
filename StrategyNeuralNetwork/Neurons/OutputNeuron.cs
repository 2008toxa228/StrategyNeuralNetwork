using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyNeuralNetwork
{
    public class OutputNeuron : RegularNeuron
    {
        public OutputNeuron(ActFunc actfunc) { this.actFunc = actfunc ?? ActivationFunctions.Sigmoid; }
        public OutputNeuron() { this.actFunc = ActivationFunctions.Sigmoid; }
    }
}
