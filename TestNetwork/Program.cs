using System;

using StrategyNeuralNetwork;

namespace TestNetwork
{
    class Program
    {
        static void Main(string[] args)
        {
            INetwork perceptron = new Perceptron
            (
                inputsCount: 4,                                                
                countInLayers: new int[]{ 8 },
                outputsCount: 3,
                bias: true, 
                actFunc: ActivationFunctions.Sigmoid
            );
            DataSet ds = new DataSet();
            ds.ReadFromTxt("iris1r.txt",4,3);
            ds.ShowData();
            Console.WriteLine("DataSet loaded.\n\nPress any key to start training...");
            Console.ReadKey();

            Console.Clear();
            DataSet trainDataSet = ds.GetPart(0.7);
            for(int i = 0; i < 2000; i++)
            {
                Console.WriteLine(perceptron.Train(trainDataSet, learnRate: 0.1).ToString("0.0000"));
            }
            Console.WriteLine("Training done.\n\nPress any key to check results..");
            Console.ReadKey();

            Console.Clear();
            Console.WriteLine("Results");
            for(int i = 0; i < ds.dataSet.Length; i++)
            {
                perceptron.SetInputs(ds.dataSet[i].Inputs);
                perceptron.FeedForward();
                double[] results = perceptron.GetOutputs();

                string str = "";
                foreach(double r in results) { str += r.ToString("0.00") + " "; }
                str += "\n";
                foreach (double d in ds.dataSet[i].Outputs) { str += d.ToString("0.00") + " "; }
                str += "\nOutputError: " + perceptron.GetSquareError(ds.dataSet[i].Outputs).ToString("0.0000") + "\n";

                Console.WriteLine(str);
            }
            Console.WriteLine("Press any key to close...");
            Console.ReadKey();
        }
    }
}
