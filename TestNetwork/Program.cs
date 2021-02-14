using System;
using System.IO;
using StrategyNeuralNetwork;

namespace TestNetwork
{
    class Program
    {
        static void Main(string[] args)
        {
            DataSet ds = new DataSet();
            ReadDataSetFromFile("iris1r.txt", ds, inputCount: 4, outputCount: 3);            

            for (decimal learnRate = 0.5m; learnRate > 0; learnRate -= 0.05m)
            {
                INetwork perceptron = new Perceptron
                (
                   inputsCount: 4,
                   countInLayers: new int[] { 8 },
                   outputsCount: 3,
                   bias: true,
                   actFunc: ActivationFunctions.Sigmoid
                );

                TrainNetwork(perceptron, ds, Convert.ToDouble(learnRate));
                ShowResult(perceptron, ds);
            }
        }

        public static void ReadDataSetFromFile(string path, DataSet ds, int inputCount, int outputCount)
        {
            ds.ReadFromTxt(path, inputCount, outputCount);
            ds.ShowData();
            Console.WriteLine("DataSet loaded.\n\nPress any key to start training...");
            Console.ReadKey();
        }

        public static void TrainNetwork(INetwork net, DataSet ds, double learnRate, int generationsCount = 1000, double trainPart = 0.7)
        {
            FileWriter fileWriter = new FileWriter(@"Training\gens" + generationsCount + "_lr" + learnRate.ToString() + ".txt");

            Console.Clear();
            DataSet trainDataSet = ds.GetPart(trainPart);
            for (int i = 0; i < generationsCount; i++)
            {
                fileWriter.WriteToFile(net.Train(trainDataSet, learnRate: learnRate).ToString("0.0000"), true);
            }
            fileWriter.Dispose();
            Console.WriteLine("Training done.\n\nPress any key to check results..");
            Console.ReadKey();
        }
        public static void ShowResult(INetwork net, DataSet ds)
        {
            Console.Clear();
            Console.WriteLine("Results");
            for (int i = 0; i < ds.dataSet.Length; i++)
            {
                net.SetInputs(ds.dataSet[i].Inputs);
                net.FeedForward();
                double[] results = net.GetOutputs();

                string str = "";
                foreach (double r in results) { str += r.ToString("0.00") + " "; }
                str += "\n";
                foreach (double d in ds.dataSet[i].Outputs) { str += d.ToString("0.00") + " "; }
                str += "\nOutputError: " + net.GetSquareError(ds.dataSet[i].Outputs).ToString("0.0000") + "\n";

                Console.WriteLine(str);
            }
            Console.WriteLine("Press any key to close...");
            Console.ReadKey();
        }
    }
}