using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace StrategyNeuralNetwork
{
    public class DataSet
    {
        public struct Data
        {
            public double[] Inputs { get; private set; }
            public double[] Outputs { get; private set; }

            public Data(double[] inputs, double[] outputs)
            {
                this.Inputs = inputs;
                this.Outputs = outputs;
            }
        }

        public Data[] dataSet { get; private set; }

        public void ReadFromTxt(string path, int inputCount, int outputCount)
        {
            string fileData = "";
            FileStream file = new FileStream(path, FileMode.Open);
            StreamReader sr = new StreamReader(file);
            fileData = sr.ReadToEnd().Replace(".",",");
            sr.Close();
            file.Close();

            string[] strValues = fileData.Split('\n');
            dataSet = new Data[strValues.Length];
            for (int i = 0; i < strValues.Length; i++)
            {
                double[] inputs = new double[inputCount];
                double[] outputs = new double[outputCount];
                string[] values = strValues[i].Split(' ');
                for(int j = 0; j < inputCount + outputCount; j++)
                {
                    if (j < inputCount) { inputs[j] = Convert.ToDouble(values[j]); }
                    else { outputs[j - inputCount] = Convert.ToDouble(values[j]); }
                }
                dataSet[i] = new Data(inputs, outputs);
            }

        }

        public DataSet GetPart(double percent)
        {
            Data[] dataSetPart = new Data[(int)(dataSet.Length * percent)];
            for (int i = 0; i < dataSetPart.Length && i < dataSet.Length; i++)
            {
                dataSetPart[i] = dataSet[i];
            }
            return new DataSet() { dataSet = dataSetPart };
        }

        public void ShowData()
        {
            string str = "";
            Data last = dataSet[dataSet.Length - 1];
            foreach (Data data in dataSet)
            {
                for(int i = 0; i < data.Inputs.Length + data.Outputs.Length; i++)
                {
                    if (i < data.Inputs.Length) { str += data.Inputs[i].ToString("0.0") + " "; }
                    else { str += data.Outputs[i - data.Inputs.Length].ToString("0.0") + " "; }
                }
                if (data.Equals(last)) break;
                str += "\n";
            }
            Console.WriteLine(str);
        }
    }
}
