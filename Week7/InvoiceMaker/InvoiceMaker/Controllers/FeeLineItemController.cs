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
    public class FeeLineItemController : Controller
    {
        private Context context;

        public FeeLineItemController()
        {
            context = new Context();
        }
        // GET: FeeLineItem
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Invoices");
        }

        [HttpGet]
        public ActionResult Add(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("Edit", "Invoices", new { id = id });
            }
            CreateFeeLineItem viewModel = new CreateFeeLineItem();
            viewModel.When = DateTimeOffset.Now;
            viewModel.InvoiceId = (int)id;
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(int id, CreateFeeLineItem viewModel)
        {
            //TODO: validation and stuff
            try
            {
                FeeLineItem item = new FeeLineItem(viewModel.Description, viewModel.Amount, viewModel.When);
                item.InvoiceId = id;
                new FeeLineItemRepository(context).Insert(item);
                return RedirectToAction("Edit", "Invoices", new { id = id });

            } catch (Exception ex) { }
            
            return View(viewModel);
        }
    }
}