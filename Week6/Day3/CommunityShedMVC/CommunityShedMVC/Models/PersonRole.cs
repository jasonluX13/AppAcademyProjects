using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommunityShedMVC.Models
{
    public class PersonRole
    {
        public int PersonId { get; set; }
        public string RoleName { get; set; }
        public int CommunityId { get; set; }
    }
}