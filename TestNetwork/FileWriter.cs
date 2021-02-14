using System;
using System.IO;

namespace TestNetwork
{

    public class FileWriter : IDisposable
    {
        public string Path { get; private set; }
        private StreamWriter sw;
        private FileStream file;

        public FileWriter(string path)
        {
            Path = path;
            file = new FileStream(Path, FileMode.Create);
            sw = new StreamWriter(file);
        }

        public void WriteToFile(string data, bool writeToConsole = false)
        {
            if (writeToConsole) Console.WriteLine(data);
            sw.WriteLine(data);
        }

        public void Dispose()
        {
            sw.Close();
            file.Close();
            GC.SuppressFinalize(this);
        }
    }
}
