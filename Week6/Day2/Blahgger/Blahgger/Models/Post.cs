using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Blahgger.Models
{
    public class Post
    {
        public int Id { get; set; }
        [Required]
        public string Text { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public int CreatorId { get; set; }
        public string CreatorName { get; set; }
    }
}