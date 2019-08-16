using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace grep
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 2)
            {
                string pattern = args[0];
                string filename = args[1];
                string line;
                //string allLines;
                try
                {
                    using (StreamReader stream = new StreamReader(filename))
                    {
                        while ((line=stream.ReadLine()) != null){
                            Regex regex = new Regex(pattern, RegexOptions.Multiline);
                            MatchCollection matches = regex.Matches(line);
                            if (matches.Count > 0)
                            {
                                Console.WriteLine(matches[0].Groups["match"].ToString());
                                Console.WriteLine("match");
                            }
                            
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                

            }
            else
            {
                Console.WriteLine("Usage: grep <pattern> <filename>");
            }
            Console.Read();
        }
    }
}
