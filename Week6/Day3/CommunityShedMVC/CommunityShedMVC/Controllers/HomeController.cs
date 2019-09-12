using CommunityShedMVC.Data;
using CommunityShedMVC.Models;
using CommunityShedMVC.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CommunityShedMVC.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public CustomPrincipal CustomUser {
            get
            {
                return (CustomPrincipal)User;
            }
        }
        // GET: Home
        public ActionResult Index()
        {
            List<Community> communities = new List<Community>();
            communities = DatabaseHelper.Retrieve<Community>(@"
                select Id, CommunityName, [Open], OwnerId 
                from Community 

            ");
            
            return View(communities);
        }

        public ActionResult AddCommunity()
        {
            return View();
        }

        public ActionResult JoinCommunity()
        {
            return View();
        }
    }
}