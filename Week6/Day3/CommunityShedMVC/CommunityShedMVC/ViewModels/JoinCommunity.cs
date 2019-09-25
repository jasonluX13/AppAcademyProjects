using CommunityShedMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommunityShedMVC.ViewModels
{
    public class JoinCommunity : BaseViewModel
    {
        public List<Community> Communities { get; set; }
    }
}