﻿using InvoiceMaker.FormModels;
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
        // GET: WorkDone
        public ActionResult Index()
        {
            WorkDoneRepository repo = new WorkDoneRepository();
            List<WorkDone> workDones = repo.GetAll();
            return View(workDones);
        }

        [HttpGet]
        public ActionResult Create()
        {
            CreateWorkDoneView model = new CreateWorkDoneView();
            model.Clients = new ClientRepository().GetClients();
            model.WorkTypes = new WorkTypeRepository().GetWorkTypes();
            return View("Create", model);
        }

        [HttpPost]
        public ActionResult Create(CreateWorkDone model)
        {
            try
            {
                // Get the client and work type based on values submitted from
                // the form
                Client client = new ClientRepository().GetById(model.ClientId);
                WorkType workType = new WorkTypeRepository().GetById(model.WorkTypeId);

                // Create an instance of the work done with the client and work
                // type
                WorkDone workDone = new WorkDone(0, client, workType);
                new WorkDoneRepository().Insert(workDone);
                return RedirectToAction("Index");
            }
            catch { }

            // Create a view model
            CreateWorkDoneView viewModel = new CreateWorkDoneView();

            // Copy over the values from the values submitted
            viewModel.ClientId = model.ClientId;
            viewModel.StartedOn = model.StartedOn;
            viewModel.WorkTypeId = model.WorkTypeId;

            // Go get the value for the drop-downs, again.
            viewModel.Clients = new ClientRepository().GetClients();
            viewModel.WorkTypes = new WorkTypeRepository().GetWorkTypes();
            return View("Create", viewModel);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("Index");
            }
            WorkDone wd = new WorkDoneRepository().GetById((int)id);
            EditWorkDoneView model = new EditWorkDoneView();
            model.Clients = new ClientRepository().GetClients();
            model.WorkTypes = new WorkTypeRepository().GetWorkTypes();
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
                        Client client = new ClientRepository().GetById(model.ClientId);
                        WorkType workType = new WorkTypeRepository().GetById(model.WorkTypeId);

                        // Create an instance of the work done with the client and work
                        // type
                        WorkDone workDone = new WorkDone(model.Id, client, workType, model.StartedOn, model.EndedOn);
                        new WorkDoneRepository().Update(workDone);
                        return RedirectToAction("Index");
                    }
                    catch { }
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
            viewModel.Clients = new ClientRepository().GetClients();
            viewModel.WorkTypes = new WorkTypeRepository().GetWorkTypes();
            return View("Edit", viewModel);

        }

    }
}