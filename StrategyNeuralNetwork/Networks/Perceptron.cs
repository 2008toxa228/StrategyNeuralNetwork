using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyNeuralNetwork
{
    public class Perceptron : INetwork
    {
        public int[] CountInLayers { get; private set; }

        public bool Bias { get; private set; }
        public ILayer[] Layers { get; set; }

        public Perceptron(int inputsCount, int[] countInLayers, int outputsCount, bool bias = false, ActFunc actFunc = null)
        {
            CountInLayers = new int[countInLayers.Length+2];
            for (int i = 0; i < countInLayers.Length; i++) { CountInLayers[i + 1] = countInLayers[i]; }
            CountInLayers[0] = inputsCount;
            CountInLayers[CountInLayers.Length - 1] = outputsCount;

            Bias = bias;

            Layers = new ILayer[CountInLayers.Length];

            Layers[0] = new RegularLayer(new InputNeuron().CreateNeurons(inputsCount, Bias));

            for(int i = 1; i < CountInLayers.Length; i++)
            {
                INeuron[] neurons = new INeuron[CountInLayers[i] + (Bias && i < CountInLayers.Length - 1 ? 1 : 0)];
                for (int j = 0; j < CountInLayers[i]; j++)
                {
                    neurons[j] = (i < CountInLayers.Length - 1 ? new RegularNeuron(actFunc) : new OutputNeuron(actFunc));
                    neurons[j].Initialize(Layers[i - 1].Neurons);
                }
                if (Bias && i < CountInLayers.Length - 1) neurons[neurons.Length - 1] = new BiasNeuron();
                Layers[i] = new RegularLayer(neurons);
            }
        }

        public void SetInputs(double[] inputs)
        {
            for (int i = 0; i < inputs.Length && i < Layers[0].Neurons.Length; i++)
                Layers[0].Neurons[i].Value = inputs[i];
        }

        public void ProcessData()
        {
            for (int i = 0; i < Layers.Length; i++)
            {
                for (int j = 0; j < Layers[i].Neurons.Length; j++)
                {
                    Layers[i].Neurons[j].Error = 0;
                    Layers[i].Neurons[j].PushInputs();
                }
            }
        }

        public double[] GetOutputs()
        {
            double[] output = new double[Layers[Layers.Length-1].Neurons.Length];
            for(int i = 0; i < output.Length; i++)
            {
                output[i] = Layers[Layers.Length - 1].Neurons[i].Output;
            }
            return output;
        }

        public void FindOutputError(double[] target)
        {
            INeuron[] neurons = Layers[Layers.Length-1].Neurons;
            for (int i = 0; i < neurons.Length && i < target.Length; i++)
            {
                neurons[i].Error = target[i] - neurons[i].Output;
            }
        }

        public void BackPropagation(double learnRate)
        {
            for (int i = Layers.Length - 1; i >= 0; i--)
            {
                INeuron[] neurons = Layers[i].Neurons;
                for (int n = 0; n < neurons.Length; n++)
                {
                    neurons[n].PassError();
                    neurons[n].CorrectWeights(learnRate);
                }
            }
        }

        public double Train(DataSet dataSet, double learnRate)
        {
            double error = 0;
            for (int i = 0; i < dataSet.dataSet.Length; i++)
            {
                SetInputs(dataSet.dataSet[i].Inputs);
                ProcessData();
                FindOutputError(dataSet.dataSet[i].Outputs);
                BackPropagation(learnRate);
                error += GetSquareError();
            }
            return error;
        }
        public double GetSquareError()
        {
            double error = 0;
            INeuron[] neurons = Layers[Layers.Length - 1].Neurons;
            for (int j = 0; j < neurons.Length; j++)
            {
                error += neurons[j].Error * neurons[j].Error;
            }
            return error / neurons.Length;
        }
        public double GetSquareError(double[] target)
        {
            FindOutputError(target);
            return GetSquareError();
        }
    }
}
