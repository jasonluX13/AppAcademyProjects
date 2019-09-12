using CommunityShedMVC.Data;
using CommunityShedMVC.Models;
using CommunityShedMVC.Security;
using CommunityShedMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CommunityShedMVC.Controllers
{
    public class ItemController : Controller
    {
        public CustomPrincipal CustomUser
        {
            get
            {
                return (CustomPrincipal)User;
            }
        }
        // GET: Item
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int? communityId)
        {
            if (communityId == null)
            {
                return RedirectToAction("Index", "Home");
            }
            //Community Name, Owner, Open and item list
            Community community = new Community();
            community = DatabaseHelper.RetrieveSingle<Community>(@"
                select Id, CommunityName, [Open], OwnerId 
                From Community
                where Id = @CommunityId
                ", new SqlParameter("@CommunityId", communityId));
            List<Item> items = new List<Item>();
            items = DatabaseHelper.Retrieve<Item>(@"
                select Item.Id, ItemName, OwnerId, Usage, Warning, Age
                from Item join CommunityItems on Item.Id = CommunityItems.ItemId
                where CommunityId = @CommunityId
            ", new SqlParameter("@CommunityId", communityId));

            DisplayCommunityDetails communityDetails = new DisplayCommunityDetails();
            communityDetails.Community = community;
            communityDetails.Items = items;
            communityDetails.OwnerName = DatabaseHelper.ExecuteScalar<string>(@"
                select FirstName + ' ' + LastName as Name
                from Person join Community on Person.Id = Community.OwnerId
                where Community.Id = @CommunityId
            ", new SqlParameter("@CommunityId", communityId));

            return View(communityDetails);
        }

        public ActionResult AddItem(int? communityId)
        {
            if (communityId == null)
            {
                return RedirectToAction("Index", "Home");
            }
            ViewBag.CommunityId = communityId;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddItem(int? communityId, Item item)
        {
            if (communityId == null)
            {
                return RedirectToAction("Index", "Home");
            }
            item.OwnerId = CustomUser.Person.Id;
            //CreateItem
            item.Id = (int)DatabaseHelper.Insert(@"
                Insert into Item(ItemName, OwnerId, Usage, Warning, Age)
                values (@ItemName, @OwnerId, @Usage, @Warning, @Age)
            ", new SqlParameter("@ItemName", item.ItemName),
            new SqlParameter("@OwnerId", item.OwnerId),
            new SqlParameter("@Usage", item.Usage),
            new SqlParameter("@Warning", item.Warning),
            new SqlParameter("@Age", item.Age));

            //Add item to shed
            DatabaseHelper.Insert(@"
                Insert into CommunityItems(ItemId, CommunityId)
                values (@ItemId, @CommunityId)
            ", new SqlParameter("@ItemId", item.Id),
            new SqlParameter("@CommunityId", communityId));

            return RedirectToAction("Details", new { communityid = communityId });
        }
    }
}