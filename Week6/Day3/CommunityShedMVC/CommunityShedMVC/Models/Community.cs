using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommunityShedMVC.Models
{
    public class Community
    {
        public int Id { get; set; }
        public string CommunityName { get; set; }
        public bool Open { get; set; }
        public int OwnerId { get; set; }
    }
}