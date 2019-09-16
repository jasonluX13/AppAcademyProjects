using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvoiceMaker
{
    public class Md5HashModule : IHttpModule
    {
        public void Dispose() { }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += HandleBeginRequest;
        }

        private void HandleBeginRequest(object sender, EventArgs e)
        {
            InvoiceMakerApplication ima = (InvoiceMakerApplication)sender;
            string path = ima.Context.Request.Path;
            if (path.StartsWith("/api/hash/"))
            {
                string text = path.Substring(10);
                text += ".hash";
                ima.Context.RewritePath(text);
            }
            else if (path.StartsWith("/api/binhash/"))
            {
                string text = path.Substring(13);
                text += ".binhash";
                ima.Context.RewritePath(text);
            }

        }
    }
}