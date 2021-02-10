using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyNeuralNetwork
{
    public class RegularLayer : ILayer
    {
        public INeuron[] Neurons { get; private set; }

        public RegularLayer(INeuron[] neurons)
        {
            this.Neurons = neurons;
            //Console.WriteLine(this.Neurons);
        }
    }
}
