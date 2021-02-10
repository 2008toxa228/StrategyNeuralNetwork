using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyNeuralNetwork
{
    public class Synapse
    {
        public INeuron neuron;
        public double weight;

        public Synapse(INeuron neuron, double weight)
        {
            this.neuron = neuron;
            this.weight = weight;
        }

        public double Product()
        {
            return neuron.Output * weight;
        }
    }
}
