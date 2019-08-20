using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ls
{
    class Program
    {
        static void Main(string[] args)
        {
            bool longFlag = false;
            if (args.Length > 0 && args[0] == "-l")
            {
                longFlag = true;
            }
        
            var filesAndDirectories = Directory.EnumerateFileSystemEntries(".");

            PrintEnumerable(filesAndDirectories, longFlag);
#if DEBUG
            Console.Read();
#endif
        }
        //Ctrl-rm to create a new method

        private static void PrintEnumerable(IEnumerable<string> directories, bool longFlag)
        {
            if (!longFlag)
            {
                foreach (var item in directories)
                {
                    string display = item.Substring(2);

                    if (Directory.Exists(item))
                    {
                        display += "/";
                    }
                    Console.WriteLine(display);

                }
            }
            else
            {
                const string format = "MMM dd HH:mm";
                string display = "";
                string name;
                display += "SIZE".PadRight(12) + "  CREATED".PadRight(14) + "  MODIFIED".PadRight(12) + "\n";
                foreach (var item in directories)
                {
                    if (!Directory.Exists(item))
                    {
                        FileInfo file = new FileInfo(item);
                        display+= file.Length.ToString().PadLeft(12);
                        name = item.Substring(2);
                    }
                    else
                    {
                        display += "".PadLeft(12);
                        name = item.Substring(2) + "/";
                    }
                    display += "  " + Directory.GetCreationTime(item).ToString(format).PadRight(10);
                    display += "  "+ Directory.GetLastAccessTime(item).ToString(format).PadRight(10);
                    display += "  " + name + "\n";
                }
                    Console.WriteLine(display);
            }
            
            Console.WriteLine();
        }
    }
}
