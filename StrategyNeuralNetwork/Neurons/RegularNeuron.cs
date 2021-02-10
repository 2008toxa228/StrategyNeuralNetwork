using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyNeuralNetwork
{
    public class RegularNeuron : INeuron
    {
        public double Output { get; private set; }
        public double Value { get; set; }
        public double Error { get; set; }
        public ActFunc actFunc = ActivationFunctions.Sigmoid;
        public Synapse[] Inputs { get; private set; }

        public RegularNeuron(ActFunc actfunc) { this.actFunc = actfunc ?? ActivationFunctions.Sigmoid; }
        public RegularNeuron() { this.actFunc = ActivationFunctions.Sigmoid; }

        public INeuron Initialize(INeuron[] inputNeurons)
        {
            Inputs = new Synapse[inputNeurons.Length];
            for(int i = 0; i < inputNeurons.Length; i++)
                Inputs[i] = new Synapse(inputNeurons[i], Rnd.GetRand());

            return this;
        }

        public void PushInputs()
        {
            Value = 0;
            for (int i = 0; i < Inputs.Length; i++)
            {
                Value += Inputs[i].Product();
            }
            Output = actFunc(Value);
        }

        public void PassError()
        {
            for (int i = 0; i < Inputs.Length; i++)
            {
                Inputs[i].neuron.Error += Error * Inputs[i].weight;
            }
        }
        public void CorrectWeights(double learnRate)
        {
            for (int i = 0; i < Inputs.Length; i++)
            {
                Inputs[i].weight += Inputs[i].neuron.Output * Error * actFunc(Value, isDerevative: true) * learnRate;
            }
        }
    }
}
