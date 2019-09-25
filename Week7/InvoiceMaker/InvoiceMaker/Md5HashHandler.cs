using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace InvoiceMaker
{
    public class Md5HashHandler : IHttpHandler
    {
        public bool IsReusable
        {
            get
            {
                return true;
            }
        }

        public void ProcessRequest(HttpContext context)
        {
            string path = context.Request.Url.AbsolutePath;
            string extension = Path.GetExtension(path);
            string value;
            
            switch (extension)
            {
                case ".hash":
                    value = path.Substring(1, path.Length - 6);
                    string hash = CalculateMD5Hash(value);
                    context.Response.ContentType = "text/plain";
                    context.Response.Write(hash);
                    break;
                case ".binhash":
                    value = path.Substring(0, path.Length - 9);
                    byte[] binhash = BinaryMD5Hash(value);
                    context.Response.ContentType = "application/octet-stream";
                    context.Response.BinaryWrite(binhash);
                    break;
            }
        }

        public string CalculateMD5Hash(string input)
        {
            // step 1, calculate MD5 hash from input
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }

        public byte[] BinaryMD5Hash(string input)
        {
            // step 1, calculate MD5 hash from input
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            return hash;
        }

    }
}