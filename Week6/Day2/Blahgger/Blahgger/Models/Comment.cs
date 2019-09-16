﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blahgger.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public int CreatorId { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public string CreatorName { get; set; }
        public string Text { get; set; }
    }
}