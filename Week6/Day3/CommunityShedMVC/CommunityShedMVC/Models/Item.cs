using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CommunityShedMVC.Models
{
    public class Item
    {
        public int Id { get; set; }
        [Required]
        public string ItemName { get; set; }
        public int OwnerId { get; set; }
        [Required]
        public string Usage { get; set; }
        [Required]
        public string Warning { get; set; }
        [Required]
        public string Age { get; set; }
        public int CommunityId { get; set; }
        public bool Borrowed { get; set; }

    }
}