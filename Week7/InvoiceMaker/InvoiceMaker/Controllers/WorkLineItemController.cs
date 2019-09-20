using InvoiceMaker.Data;
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

        
    }
}