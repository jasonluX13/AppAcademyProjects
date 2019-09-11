using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blahgger.Models
{
    public class DisplayPost
    {
        public Post Post { get; set; }
        public List<Comment> Comments { get; set; }
    }
}