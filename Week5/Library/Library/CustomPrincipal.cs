using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace Library
{
    public class CustomPrincipal : IPrincipal
    {
        private CustomIdentity identity;
        private string[] roles;

        public CustomPrincipal(CustomIdentity identity, string[] roles)
        {
            this.identity = identity;
            this.roles = roles;
        }

        public IIdentity Identity
        {
            get
            {
                return identity;
            }
        }

        public CustomIdentity CustomIdentity
        {
            get
            {
                return identity;
            }
        }

        public bool IsLibrarian
        {
            get
            {
                return IsInRole("Librarian");
            }
        }

        public bool IsPatron
        {
            get
            {
                return IsInRole("Patron");
            }
        }

        public bool IsInRole(string role)
        {
            foreach (var r in roles)
            {
                if (r == role)
                {
                    return true;
                }
            }
            return false;
        }
    }
}