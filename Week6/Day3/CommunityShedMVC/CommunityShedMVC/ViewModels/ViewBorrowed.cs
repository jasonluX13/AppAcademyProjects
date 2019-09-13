using CommunityShedMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommunityShedMVC.ViewModels
{
    public class ViewBorrowed : Borrowed
    {
        public string ItemName { get; set; }
        public string CommunityName { get; set; }
        public int CommunityId { get; set; }
    }
}