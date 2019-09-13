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
    [Authorize]
    public class HomeController : Controller
    {
        public CustomPrincipal CustomUser
        {
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
                select Community.Id, CommunityName, [Open], OwnerId 
                from Community join PersonRole on Community.Id = PersonRole.CommunityId
                where PersonRole.PersonId = @PersonId
                group by PersonId, Community.Id, CommunityName, [Open], OwnerId
            ", new SqlParameter("@PersonId", CustomUser.Person.Id));

            return View(communities);
        }

        public ActionResult CommunityDetails()
        {
            List<Community> communities = new List<Community>();
            communities = DatabaseHelper.Retrieve<Community>(@"
                select Id, CommunityName, [Open], OwnerId 
                from Community 
            ");
            JoinCommunity viewModel = new JoinCommunity();
            viewModel.Communities = communities;

            return View(viewModel);
        }

        
        public ActionResult AddCommunity()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCommunity(Community community)
        {
            try
            {
                community.OwnerId = CustomUser.Person.Id;
                //Add new entry for community
                community.Id = (int)DatabaseHelper.Insert(@"
                    Insert into Community(CommunityName, [Open], OwnerId)
                    values (@CommunityName, @Open, @OwnerId)

                ", new SqlParameter("@CommunityName", community.CommunityName),
                new SqlParameter("@Open", community.Open),
                new SqlParameter("@OwnerId", community.OwnerId)
                );
                //Add new entry for PersonRole
                DatabaseHelper.Insert(@"
                    Insert into PersonRole(PersonId, RoleId, CommunityId)
                    values (@PersonId, @RoleId, @CommunityId)

                ", new SqlParameter("@PersonId", CustomUser.Person.Id),
                new SqlParameter("@RoleId", 1),
                new SqlParameter("@CommunityId", community.Id)
                );

                DatabaseHelper.Insert(@"
                    Insert into PersonRole(PersonId, RoleId, CommunityId)
                    values (@PersonId, @RoleId, @CommunityId)

                ", new SqlParameter("@PersonId", CustomUser.Person.Id),
               new SqlParameter("@RoleId", 2),
               new SqlParameter("@CommunityId", community.Id)
               );
                DatabaseHelper.Insert(@"
                    Insert into PersonRole(PersonId, RoleId, CommunityId)
                    values (@PersonId, @RoleId, @CommunityId)

                ", new SqlParameter("@PersonId", CustomUser.Person.Id),
               new SqlParameter("@RoleId", 3),
               new SqlParameter("@CommunityId", community.Id)
               );
                DatabaseHelper.Insert(@"
                    Insert into PersonRole(PersonId, RoleId, CommunityId)
                    values (@PersonId, @RoleId, @CommunityId)

                ", new SqlParameter("@PersonId", CustomUser.Person.Id),
               new SqlParameter("@RoleId", 4),
               new SqlParameter("@CommunityId", community.Id)
               );
                SetOwnerRoles(community.Id);

                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }

        }

        
        public ActionResult JoinCommunity(int? communityId)
        {
            if (communityId == null)
            {
                return RedirectToAction("Index");
            }

            //bool open = DatabaseHelper.ExecuteScalar<bool>(@"
            //    select [Open] from Community
            //    where Id = @Id
            //", new SqlParameter("@Id", communityId));

            //check if user already joined
            int? p = DatabaseHelper.ExecuteScalar<int?>(@"
                select PersonId from PersonRole
                where CommunityId = @CommunityId and PersonId = @PersonId and RoleId = 1
            ", new SqlParameter("@PersonId",CustomUser.Person.Id),
             new SqlParameter("@CommunityId", communityId));
            if (p != null)
            {
                return RedirectToAction("AlreadyJoined");
            }

            DatabaseHelper.Insert(@"
                Insert into PersonRole(PersonId, RoleId, CommunityId)
                values (@PersonId, @RoleId, @CommunityId)
            ", new SqlParameter("@PersonId", CustomUser.Person.Id),
             new SqlParameter("@RoleId", 1),
             new SqlParameter("@CommunityId", communityId));

            return RedirectToAction("Index");
        }

        public ActionResult AlreadyJoined()
        {
            return View();
        }


        private void SetOwnerRoles(int communityId)
        {
            DatabaseHelper.Insert(@"
                    Insert into PersonRole(PersonId, RoleId, CommunityId)
                    values (@PersonId, @RoleId, @CommunityId)

                ", new SqlParameter("@PersonId", CustomUser.Person.Id),
                new SqlParameter("@RoleId", 1),
                new SqlParameter("@CommunityId", communityId)
            );

            DatabaseHelper.Insert(@"
                    Insert into PersonRole(PersonId, RoleId, CommunityId)
                    values (@PersonId, @RoleId, @CommunityId)

                ", new SqlParameter("@PersonId", CustomUser.Person.Id),
                new SqlParameter("@RoleId", 2),
                new SqlParameter("@CommunityId", communityId)
            );

            DatabaseHelper.Insert(@"
                    Insert into PersonRole(PersonId, RoleId, CommunityId)
                    values (@PersonId, @RoleId, @CommunityId)

                ", new SqlParameter("@PersonId", CustomUser.Person.Id),
                new SqlParameter("@RoleId", 3),
                new SqlParameter("@CommunityId", communityId)
            );

            DatabaseHelper.Insert(@"
                    Insert into PersonRole(PersonId, RoleId, CommunityId)
                    values (@PersonId, @RoleId, @CommunityId)

                ", new SqlParameter("@PersonId", CustomUser.Person.Id),
                new SqlParameter("@RoleId", 4),
                new SqlParameter("@CommunityId", communityId)
            );

        }

    }
}