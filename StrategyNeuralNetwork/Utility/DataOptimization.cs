using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyNeuralNetwork
{
    public class DataOptimization
    {
        double Avg = 0;
        double dJ = 1;
        double Min = 0, Max = 1;

        public void ChangeValues(double[] data)
        {
            Avg = 0;
            for (int i = 0; i < data.Length; i++)
            {
                Avg += data[i];
            }
            Avg = Avg / data.Length;

            dJ = 0;
            for (int i = 0; i < data.Length; i++)
            {
                dJ += Math.Pow(data[i] - Avg, 2);
            }
            dJ = Math.Sqrt(dJ / data.Length);

            for (int i = 0; i < data.Length; i++)
            {
                data[i] = (data[i] - Avg) / dJ;
            }

            Min = double.MaxValue;
            Max = double.MinValue;
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] > Max) { Max = data[i]; }
                if (data[i] < Min) { Min = data[i]; }
            }
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = (data[i] - Min) / (Max - Min);
            }
        }

        public double Optimize(double data)
        {
            data = Scaling(Normalization(data));
            return data;
        }

        public double Normalization(double data)
        {
            data = (data - Avg) / dJ;
            return data;
        }
        public double Scaling(double data)
        {
            data = (data - Min) / (Max - Min);
            return data;
        }
    }
}
