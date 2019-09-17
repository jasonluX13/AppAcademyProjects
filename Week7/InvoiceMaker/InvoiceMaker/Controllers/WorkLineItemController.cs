using InvoiceMaker.Models;
using InvoiceMaker.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InvoiceMaker.Controllers
{
    public class WorkLineItemController : Controller
    {
        // GET: WorkLineItem
        public ActionResult Index()
        {
            WorkLineItemRepository repo = new WorkLineItemRepository();
            List<WorkLineItem> workLineItems = repo.GetWorkLineItems();
            return View(workLineItems);
        }
    }
}