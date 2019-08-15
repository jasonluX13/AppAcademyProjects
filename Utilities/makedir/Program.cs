using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace makedir
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 1)
            {
                if (Directory.Exists(args[0]))
                {
                    Console.Error.WriteLine("Error, directory already exists");
                }
                else
                {
                    try
                    {
                        Directory.CreateDirectory(args[0]);
                    }
                    catch (Exception e)
                    {
                        Console.Error.WriteLine(e);
                    }
                }
               
            }
            else
            {
                Console.WriteLine("Usage: makedir <directory name>");
            }
        }
    }
}


