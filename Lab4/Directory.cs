using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace Lab4
{
    public class Directoryy
    {
        static void Main(string[] args)
        {
            string dataFolder = "data";
            string dataFilePath = Path.Combine(dataFolder, "data.txt");
            string data2Folder = "data2";

            if (!Directory.Exists(dataFolder))
            {
                Directory.CreateDirectory(dataFolder);
                Console.WriteLine($"Created directory: {dataFolder}");
            }

            using (StreamWriter writer = new StreamWriter(dataFilePath))
            {
                writer.WriteLine("MSSV : PS45696");
                writer.WriteLine("Ho ten : Ha Ngoc Gia Bao");
            }
            Console.WriteLine($"Created file: {dataFilePath}");

            if (!Directory.Exists(data2Folder))
            {
                Directory.CreateDirectory(data2Folder);
                Console.WriteLine($"Created directory: {data2Folder}");
            }

            DirectoryInfo dirInfo = new DirectoryInfo(dataFolder);
            FileInfo[] files = dirInfo.GetFiles();

            foreach (FileInfo file in files)
            {
                string desPath = Path.Combine(data2Folder, file.Name);
                file.CopyTo(desPath, true);
                Console.WriteLine("Copied file: " + file.Name + " to " + desPath);
            }

            Console.WriteLine("All files copied successfully!");
            Console.WriteLine("Press any key to exit...");
        }
    }
}