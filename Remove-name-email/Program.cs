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
        //ENG: Put your filepath + Filename here for example @"C:\Users\yourname\Documents\yourfilename.txt"
        //NL: Stop jouw filepad + Filenaam hier bijvoorbeel @"C:\gebruiker\jouwnaam\documenten\jouwfilenaam.txt"
        string filePath = @"C:\Users\Cedric\Documents\nameremover\beterEmailList.txt";

        //This is the variable that saves the filename
        string fileName;

        //This is the function that reads the input file
        void readFile(string file)
        {
            List<string> fixedEmailList = new List<string>();
            const Int32 BufferSize = 512;
            using (var fileStream = File.OpenRead(file))
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
            {
                String line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    string output = line.Substring(line.IndexOf('@') + 1);
                    fixedEmailList.Add(output);
                    Console.WriteLine(line);
                }
                addFile(fixedEmailList);
            }
        }
        //This is the function that adds the file to the file and saves it to the desktop with the enterd name
        void addFile(List<string> fixedEmailList)
        {
            string saveFilePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            TextWriter writer = new StreamWriter($"{saveFilePath}\\{fileName}.txt");
            foreach(string email in fixedEmailList)
            {
                writer.WriteLine(email);
            }
            writer.Close();
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("ENG: Your data has been saved on the desktop!");
            Console.WriteLine("NL: Uw data is up de desktop opgeslagen!");
            Console.ReadKey();
        }
        
        //This runs the script
        void Run()
        {
            Console.WriteLine("ENG: What do you want your file to be named?");
            Console.WriteLine("NL: Hoe wilt u dat uw file genoemd word?");
            fileName = Console.ReadLine();
            Console.WriteLine("--------------------------------------------------");
            readFile(filePath);
        }
        //This is the main
        static void Main(string[] args)
        {
            Program program = new Program();
            program.Run();
        }
    }
}
