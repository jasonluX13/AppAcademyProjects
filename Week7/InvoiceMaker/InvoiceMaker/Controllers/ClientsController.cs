using InvoiceMaker.Models;
using InvoiceMaker.Repositories;
using System;
using System.Collections.Generic;
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
    }
}