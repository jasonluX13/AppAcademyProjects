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
    public class WorkTypesController : Controller
    {
        // GET: WorkTypes
        public ActionResult Index()
        {
            WorkTypeRepository repo = new WorkTypeRepository();
            List<WorkType> workTypes = repo.GetWorkTypes();
            return View(workTypes);
        }

        [HttpGet]
        public ActionResult Create()
        {
            CreateWorkType workType = new CreateWorkType();
            return View("Create", workType);
        }

        [HttpPost]
        public ActionResult Create(CreateWorkType workType)
        {
            WorkTypeRepository repo = new WorkTypeRepository();
            try
            {
                WorkType newWorkType = new WorkType(0, workType.Name, workType.Rate);
                repo.Insert(newWorkType);
                return RedirectToAction("Index");
            }
            catch (SqlException se)
            {
                if (se.Number == 2627)
                {
                    ModelState.AddModelError("Name", "That name has already been taken");
                }
            }
            return View("Create", workType);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("Index");
            }
            WorkTypeRepository repo = new WorkTypeRepository();
            WorkType workType = repo.GetById((int)id);
            if (workType == null)
            {
                return RedirectToAction("Index");
            }
            EditWorkType editWorkType = new EditWorkType();
            editWorkType.Id = workType.Id;
            editWorkType.Name = workType.Name;
            editWorkType.Rate = workType.Rate;
            return View(editWorkType);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id, EditWorkType editWorkType)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("Index");
            }
            WorkTypeRepository repo = new WorkTypeRepository();
            try
            {
                WorkType workType = new WorkType(editWorkType.Id, editWorkType.Name, editWorkType.Rate);
                repo.Update(workType);
                return RedirectToAction("Index");
            }
            catch
            {

            }
            return View(editWorkType);
        }
    }
}