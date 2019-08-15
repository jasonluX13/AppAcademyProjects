using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace touch
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 1)
            {
                string filename = args[0];
                if (File.Exists(filename))
                {
                    //Update last modified time
                    File.SetLastAccessTime(filename, DateTime.Now);
                }
                else
                {
                    //Create new file
                    File.Create(filename);
                }
            }
        }
    }
}
