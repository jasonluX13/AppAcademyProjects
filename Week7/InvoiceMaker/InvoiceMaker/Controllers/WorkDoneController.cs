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
    public class WorkDoneController : Controller
    {
        private Context context;
        public WorkDoneController()
        {
            context = new Context();
        }
        // GET: WorkDone
        public ActionResult Index()
        {
            WorkDoneRepository repo = new WorkDoneRepository(context);
            List<WorkDone> workDones = repo.GetAll();
            return View(workDones);
        }

        [HttpGet]
        public ActionResult Create()
        {
            CreateWorkDoneView model = new CreateWorkDoneView();
            model.Clients = new ClientRepository(context).GetClients();
            model.WorkTypes = new WorkTypeRepository(context).GetWorkTypes();
            return View("Create", model);
        }

        [HttpPost]
        public ActionResult Create(CreateWorkDone model)
        {
            try
            {
                // Get the client and work type based on values submitted from
                // the form
                Client client = new ClientRepository(context).GetById(model.ClientId);
                WorkType workType = new WorkTypeRepository(context).GetById(model.WorkTypeId);

                // Create an instance of the work done with the client and work
                // type
                WorkDone workDone = new WorkDone(client, workType);  /////////
                new WorkDoneRepository(context).Insert(workDone);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
            }

            // Create a view model
            CreateWorkDoneView viewModel = new CreateWorkDoneView();

            // Copy over the values from the values submitted
            viewModel.ClientId = model.ClientId;
            viewModel.StartedOn = model.StartedOn;
            viewModel.WorkTypeId = model.WorkTypeId;

            // Go get the value for the drop-downs, again.
            viewModel.Clients = new ClientRepository(context).GetClients();
            viewModel.WorkTypes = new WorkTypeRepository(context).GetWorkTypes();
            return View("Create", viewModel);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("Index");
            }
            WorkDone wd = new WorkDoneRepository(context).GetById((int)id);
            EditWorkDoneView model = new EditWorkDoneView();
            model.Clients = new ClientRepository(context).GetClients();
            model.WorkTypes = new WorkTypeRepository(context).GetWorkTypes();
            model.ClientId = wd.GetClientId();
            model.WorkTypeId = wd.GetWorkTypeId();
            model.StartedOn = wd.StartedOn;
            model.EndedOn = wd.EndedOn;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditWorkDone model)
        {
            if (ModelState.IsValidField("StartedOn") && ModelState.IsValidField("EndedOn"))
            {
                if (model.StartedOn > model.EndedOn)
                {
                    ModelState.AddModelError("", "Start date must be before end date");
                }
                else
                {
                    try
                    {
                        // Get the client and work type based on values submitted from
                        // the form
                        Client client = new ClientRepository(context).GetById(model.ClientId);
                        WorkType workType = new WorkTypeRepository(context).GetById(model.WorkTypeId);

                        // Create an instance of the work done with the client and work
                        // type
                        WorkDone workDone = new WorkDone( model.Id, client, workType, model.StartedOn, model.EndedOn);
                        new WorkDoneRepository(context).Update(workDone);
                        return RedirectToAction("Index");
                    }
                    catch(Exception ex)
                    { }
                }  
            }
            else
            {
                ModelState.AddModelError("", "Invalid date values");
            }
           
            // Create a view model
            EditWorkDoneView viewModel = new EditWorkDoneView();

            // Copy over the values from the values submitted
            viewModel.ClientId = model.ClientId;
            viewModel.StartedOn = model.StartedOn;
            viewModel.EndedOn = model.EndedOn;
            viewModel.WorkTypeId = model.WorkTypeId;

            // Go get the value for the drop-downs, again.
            viewModel.Clients = new ClientRepository(context).GetClients();
            viewModel.WorkTypes = new WorkTypeRepository(context).GetWorkTypes();
            return View("Edit", viewModel);

        }

    }
}