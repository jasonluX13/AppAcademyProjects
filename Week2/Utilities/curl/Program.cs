using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace curl
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 1)
            {
                string url = args[0];
                string html;
                try
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

                    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                    using (Stream stream = response.GetResponseStream())
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        html = reader.ReadToEnd();
                    }
                    Console.WriteLine(html);
                } catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            else
            {
                Console.WriteLine("Usage: curl <url>");
            }
        }
    }
}
