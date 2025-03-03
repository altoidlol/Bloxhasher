using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bloxhasher
{
    internal class Program
    {
        static String GetTimestamp()
        {
            return DateTime.Now.ToString("yyyyMMdd");
        }

        // Sorry for sloppy code
        static void WriteToConsole(string text, string modifier)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(GetTimestamp() + ": ");

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write('[');
            if (modifier == "+")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write('+');
            }
            else if (modifier == "-")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write('-');
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Debug");
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(']');

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(text);
        }

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Made by altoidlol (DC: @altoidlol) <3");

            WriteToConsole("Starting...", "bigblackmen");
            WriteToConsole("Getting path...", "bigblackmen");
            string rblx_path = Hashing.GetRblxPath();
            if (string.IsNullOrEmpty(rblx_path))
            {
                WriteToConsole("Unable to get path.", "-");
                Thread.Sleep(1000);
                return; 
            }

            WriteToConsole("Creating hash...", "bigblackmen");
            string hash = Hashing.CreateDirectoryMd5(rblx_path);

            WriteToConsole("Finished!", "+");
            WriteToConsole(hash, "+");

            Console.ReadLine();
        }
    }
}
