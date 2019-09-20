using InvoiceMaker.Data;
using InvoiceMaker.FormModels;
using InvoiceMaker.Models;
using InvoiceMaker.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InvoiceMaker.Controllers
{
    public class InvoicesController: Controller
    {
        private Context context;
        public InvoicesController()
        {
            context = new Context();
        }

        public ActionResult Index()
        {
            InvoiceRepository repo = new InvoiceRepository(context);
            List<Invoice> invoices = repo.GetList();
            return View("Index",invoices);
        }

        [HttpGet]
        public ActionResult Create()
        {
            //Form with dropdown of clients
            CreateInvoiceView viewModel = new CreateInvoiceView();
            viewModel.Clients = new ClientRepository(context).GetClients();
            return View("Create", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateInvoice model)
        {
            try
            {
                Client client = new ClientRepository(context).GetById(model.ClientId);
                Invoice newInvoice = new Invoice(model.InvoiceNumber, client);
                new InvoiceRepository(context).Insert(newInvoice);
                return RedirectToAction("Index");
            }
            catch { }
            
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("Index");
            }
            Invoice invoice = new InvoiceRepository(context).GetById((int)id);
            return View(invoice);
        }
    }
}