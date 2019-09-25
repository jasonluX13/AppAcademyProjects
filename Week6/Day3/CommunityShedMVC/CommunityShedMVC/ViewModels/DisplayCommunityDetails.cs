using CommunityShedMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommunityShedMVC.ViewModels
{
    public class DisplayCommunityDetails : BaseViewModel
    {
        public Community Community { get; set; }
        public List<Item> Items { get; set; }
        public string OwnerName { get; set; }
    }
}