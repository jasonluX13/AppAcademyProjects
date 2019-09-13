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
            return RedirectToAction("Index", "Home");
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
                select Item.Id, Item.ItemName, Item.OwnerId, Item.Usage, Item.Warning, Item.Age, Item.CommunityId, 
                case when DateBorrowed is not null and DateReturned is null then cast(1 as bit) 
                else cast(0 as bit) end as Borrowed
                from Item left join BorrowItem on Item.Id = BorrowItem.ItemId 
                where DateReturned is null and CommunityId = @CommunityId
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
                Insert into Item(ItemName, OwnerId, Usage, Warning, Age, CommunityId)
                values (@ItemName, @OwnerId, @Usage, @Warning, @Age, @CommunityId)
            ", new SqlParameter("@ItemName", item.ItemName),
            new SqlParameter("@OwnerId", item.OwnerId),
            new SqlParameter("@Usage", item.Usage),
            new SqlParameter("@Warning", item.Warning),
            new SqlParameter("@Age", item.Age),
            new SqlParameter("@CommunityId", communityId));

            return RedirectToAction("Details", new { communityid = communityId });
        }

        public ActionResult EditItem(int? communityId, int? id)
        {
            if (communityId == null || id == null)
            {
                return RedirectToAction("Index", "Home");
            }
            if (!isOwner((int)id) && !CustomUser.IsInRole((int)communityId, "Reviewer"))
            {
                return RedirectToAction("Index", "Home");
            }
            ViewBag.CommunityId = communityId;
            Item item = new Item();
            item = DatabaseHelper.RetrieveSingle<Item>(@"
                select Item.Id, ItemName, OwnerId, Usage, Warning, Age, CommunityId
                from Item
                where Item.Id = @ItemId and CommunityId = @CommunityId
            ", new SqlParameter("@ItemId", id),
            new SqlParameter("@CommunityId", communityId));

            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditItem(int? communityId, int? id, Item item)
        {
            if (!isOwner((int)id) && !CustomUser.IsInRole((int)communityId, "Reviewer"))
            {
                return RedirectToAction("Index", "Home");
            }
            if (ModelState.IsValid)
            {
                DatabaseHelper.Update(@"
                 update Item set
                    ItemName = @ItemName,
                    Usage = @Usage,
                    Warning = @Warning,
                    Age = @Age
                where Id = @ItemId
            ",
                new SqlParameter("@ItemId", item.Id),
                new SqlParameter("@ItemName", item.ItemName),
                new SqlParameter("@Usage", item.Usage),
                new SqlParameter("@Warning", item.Warning),
                new SqlParameter("@Age", item.Age));

                return RedirectToAction("Details", new { communityId = communityId });
            }

            return View(item);
        }

        public ActionResult Borrow(int? communityId, int? id)
        {
            Item item = new Item();
            item = DatabaseHelper.RetrieveSingle<Item>(@"
                select Item.Id, ItemName, OwnerId, Usage, Warning, Age, Borrowed
                from Item
                where Item.Id = @Id and CommunityId = @CommunityId
            ", new SqlParameter("@Id", id),
            new SqlParameter("@CommunityId", communityId));
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Borrow(int? communityId, int? id, Item item)
        {
            if (communityId == null || id == null)
            {
                return RedirectToAction("Index", "Home");
            }

            //Check if user is in community
            if (!CustomUser.IsInRole((int)communityId, "Member"))
            {
                return RedirectToAction("Index", "Home");
            }
            //Insert into BorrowItem
            DatabaseHelper.Insert(@"
                Insert into BorrowItem(ItemId, BorrowerId, DateBorrowed, DateDue)
                values (@ItemId, @BorrowerId, @DateBorrowed, @DateDue)               
            ",
            new SqlParameter("@ItemId", id),
            new SqlParameter("@BorrowerId", CustomUser.Person.Id),
            new SqlParameter("@DateBorrowed", DateTimeOffset.Now),
            new SqlParameter("@DateDue", DateTimeOffset.Now.AddDays(7))

            );

            return RedirectToAction("Details", new { communityid = communityId });

        }

        public ActionResult BorrowedItems()
        {
            List<ViewBorrowed> borrowed = new List<ViewBorrowed>();
            borrowed = DatabaseHelper.Retrieve<ViewBorrowed>(@"
                Select BorrowItem.Id, ItemId, BorrowerId, DateBorrowed, DateDue, DateReturned, CommunityName, ItemName, CommunityId
                From BorrowItem join Item on BorrowItem.ItemId = Item.Id
                join Community on Item.CommunityId = Community.Id
                Where BorrowerId = @Id
                Order By DateReturned Asc
            ", new SqlParameter("@Id", CustomUser.Person.Id));

            return View(borrowed);
        }

        public ActionResult Return(int? communityId, int? id)
        {
            ViewBorrowed borrowedItem = new ViewBorrowed();
            borrowedItem = DatabaseHelper.RetrieveSingle<ViewBorrowed>(@"
                Select ItemId, BorrowerId, DateBorrowed, DateDue, DateReturned, CommunityName, ItemName, CommunityId
                From BorrowItem join Item on BorrowItem.ItemId = Item.Id
                join Community on Item.CommunityId = Community.Id
                Where BorrowItem.Id = @Id
            ", new SqlParameter("@Id", id));

            return View(borrowedItem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Return(int? communityId, int? id, ViewBorrowed borrowed)
        {
            if (communityId == null || id == null)
            {
                return RedirectToAction("BorrowedItems");
            }
            if (CustomUser.Person.Id != id)
            {
                return RedirectToAction("Index", "Home");
            }
            DatabaseHelper.Update(@"
                Update BorrowItem
                set DateReturned = @DateReturned
                Where Id = @Id
            ", new SqlParameter("@Id", id),
            new SqlParameter("@DateReturned", DateTimeOffset.Now));

            return RedirectToAction("BorrowedItems");
        }

        public ActionResult Delete(int? communityId, int? id)
        {
            if (communityId == null || id == null)
            {
                return RedirectToAction("Index", "Home");
            }
            Item item = new Item();
            item = DatabaseHelper.RetrieveSingle<Item>(@"
                select Item.Id, ItemName, OwnerId, Usage, Warning, Age, CommunityId
                from Item
                where Item.Id = @ItemId and CommunityId = @CommunityId
            ", new SqlParameter("@ItemId", id),
            new SqlParameter("@CommunityId", communityId));
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int? communityid, int? id, Item item)
        {
            if (CustomUser.Person.Id != item.OwnerId && !CustomUser.IsInRole((int)communityid, "Reviewer"))
            {
                return RedirectToAction("Index", "Home");
            }
            //Check if it is borrowed
            ViewBorrowed borrow = new ViewBorrowed();
            borrow = DatabaseHelper.RetrieveSingle<ViewBorrowed>(@"
                select Item.Id, Item.ItemName, Item.OwnerId, Item.Usage, Item.Warning, Item.Age, Item.CommunityId, 
                case when DateBorrowed is not null and DateReturned is null then cast(1 as bit) 
                else cast(0 as bit) end as Borrowed
                from Item left join BorrowItem on Item.Id = BorrowItem.ItemId 
                where DateReturned is null and CommunityId = @CommunityId and ItemId = @ItemId
            ", new SqlParameter("@CommunityId", (int)communityid),
            new SqlParameter("@ItemId", (int)id));
            if (borrow.DateReturned == null)
            {
                return RedirectToAction("Index", "Home");
            }
            DatabaseHelper.Execute(@"
                Delete from Item
                where Id = @Id
            ", new SqlParameter("@Id", id));

            return RedirectToAction("Details", new { communityid = communityid, id = id });
        }

        private bool isOwner(int itemId)
        {
            Item item = new Item();
            item = DatabaseHelper.RetrieveSingle<Item>(@"
                select Id, ItemName, OwnerId, Usage, Warning, Age
                from Item where OwnerId = @OwnerId and Id=@ItemId
                ", new SqlParameter("@OwnerId", CustomUser.Person.Id),
                new SqlParameter("@ItemId", itemId));
            return item != null;
        }
    }
}