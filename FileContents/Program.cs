using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileContents
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Get the search string from the user
            string folderPath = "E:\\Logs\\UtilitiesApiLogs";
            Console.Write("Enter search string: ");
            string searchString = Console.ReadLine();

            // Check if the folder exists
            if (!Directory.Exists(folderPath))
            {
                Console.WriteLine("Folder does not exist.");
                return;
            }

            // Search for the string in each text file in the folder
            string[] files = Directory.GetFiles(folderPath, "*.txt*", SearchOption.AllDirectories);
            foreach (string file in files)
            {
                Console.Write(".");
                try
                {
                    string contents = File.ReadAllText(file);
                    if (contents.Contains(searchString))
                    {
                        Console.WriteLine("Found '{0}' in file: {1}", searchString, file);
                    }
                }
                catch (Exception ex)
                {
                    continue;
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
