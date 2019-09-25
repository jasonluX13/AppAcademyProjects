using InvoiceMaker.Data;
using InvoiceMaker.FormModels;
using InvoiceMaker.Models;
using InvoiceMaker.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace InvoiceMaker.Controllers
{
    public class WorkLineItemController : Controller
    {
        private Context context;

        public WorkLineItemController()
        {
            context = new Context();
        }
        // GET: WorkLineItem
        public ActionResult Index()
        {
            WorkLineItemRepository repo = new WorkLineItemRepository(context);
            List<WorkLineItem> workLineItems = repo.GetWorkLineItems();
            return View(workLineItems);
        }

        [HttpGet]
        public ActionResult Add(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("Index", "Invoice");
            }
            //Dropdown list of finished workdones for the client on the invoice
            Invoice invoice = new InvoiceRepository(context).GetById((int)id);
            CreateWorkLineItemView viewModel = new CreateWorkLineItemView();
            viewModel.workDones = context.WorkDones
                .Include(wd => wd.WorkType)
                .Where(wd => wd.ClientId == invoice.ClientId)
                .Where(wd => wd.EndedOn != null)
                .ToList();
            viewModel.InvoiceId = (int)id;
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Add(int id, CreateWorkLineItem lineItem)
        {
            try
            {
                WorkLineItem wli = new WorkLineItem()
                {
                    WorkDone = new WorkDoneRepository(context).GetById(lineItem.WorkDoneId),
                    InvoiceId = id,
                    WorkDoneId = lineItem.WorkDoneId
                };
                new WorkLineItemRepository(context).Insert(wli);
                return RedirectToAction("Edit", "Invoices", new { id = id });
            }
            catch(Exception ex)
            {
            }

            return View();
        }
        
    }
}