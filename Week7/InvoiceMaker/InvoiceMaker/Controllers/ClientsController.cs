using InvoiceMaker.FormModels;
using InvoiceMaker.Models;
using InvoiceMaker.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InvoiceMaker.Controllers
{
    public class ClientsController : Controller
    {
        // GET: Clients
        public ActionResult Index()
        {
            ClientRepository repo = new ClientRepository();
            List<Client> clients = repo.GetClients();
            return View("Index", clients);
        }

        [HttpGet]
        public ActionResult Create()
        {
            // Create a client form model and set it's
            // active flag to true because we want them
            // to be active by default.
            CreateClient client = new CreateClient();
            client.IsActivated = true;
            return View("Create", client);
        }

        [HttpPost]
        public ActionResult Create(CreateClient client)
        {
            ClientRepository repo = new ClientRepository();
            try
            {
                Client newClient = new Client(0, client.Name, client.IsActivated);
                repo.Insert(newClient);
                return RedirectToAction("Index");
            }
            catch (SqlException se)
            {
                if (se.Number == 2627)
                {
                    ModelState.AddModelError("Name", "That name is already taken.");
                }
            }
            return View("Create", client);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ClientRepository repo = new ClientRepository();
            Client client = repo.GetById(id);

            EditClient model = new EditClient();
            model.Id = client.Id;
            model.IsActivated = client.IsActive;
            model.Name = client.Name;
            return View("Edit", model);
        }

        [HttpPost]
        public ActionResult Edit(int id, EditClient client)
        {
            ClientRepository repo = new ClientRepository();
            try
            {
                Client newClient = new Client(id, client.Name, client.IsActivated);
                repo.Update(newClient);
                return RedirectToAction("Index");
            }
            catch (SqlException se)
            {
                if (se.Number == 2627)
                {
                    ModelState.AddModelError("Name", "That name is already taken.");
                }
            }
            return View("Edit", client);
        }
    }
}