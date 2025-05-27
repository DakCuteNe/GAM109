using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GAM109.Lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "data.txt";

            string username = "admin";
            string password = "123456";

            using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            using (StreamWriter writer = new StreamWriter(fs))
            {
                writer.WriteLine("Username: " + username);
                writer.WriteLine("Password: " + password);
            }
            Console.WriteLine("Data has been written to " + filePath);

            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            using (StreamReader reader = new StreamReader(fs))
            {
                Console.WriteLine("Reading data from " + filePath);
                string? line;
                while ((line = reader.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
        }
    }
}