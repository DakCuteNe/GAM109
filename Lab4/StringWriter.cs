using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GAM109.Lab4
{
    class Writer
    {
        static void Main(string[] args)
        {
            string username = "admin";
            string password = "123456";
            string line = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

            string data;

            using (StringWriter writer = new StringWriter())
            {
                writer.WriteLine("Username: " + username);
                writer.WriteLine("Password: " + password);
                writer.Write("Time Saved: " + line);

                data = writer.ToString();
            }

            using (StringReader reader = new StringReader(data))
            {
                Console.WriteLine("Reading data:");
                string? readLine;
                while ((readLine = reader.ReadLine()) != null)
                {
                    Console.WriteLine(readLine);
                }
            }
        }
    }
}