using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Remove_name_email
{
    class Program
    {
        string filePath = @"C:\Users\Cedric\Documents\nameremover\beterEmailList.txt";

         void readFile(string file)
        {
            const Int32 BufferSize = 512;
            using (var fileStream = File.OpenRead(file))
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
            {
                String line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    string output = line.Substring(line.IndexOf('@') + 1);
                    Console.WriteLine(output);
                }
                Console.ReadKey();
            }
        }

        void Run()
        {
            readFile(filePath);
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            program.Run();
        }
    }
}
