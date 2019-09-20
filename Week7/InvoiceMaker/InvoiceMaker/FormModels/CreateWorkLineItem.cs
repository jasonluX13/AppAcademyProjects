using InvoiceMaker.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InvoiceMaker.FormModels
{
    public class CreateWorkLineItem
    {
        public int InvoiceId { get; set; }
        [Display(Name = "Work Done")]
        public int WorkDoneId { get; set; }

    }

    public class CreateWorkLineItemView : CreateWorkLineItem
    {
        public List<WorkDone> workDones { get; set; }

        public List<SelectListItem> WorkDoneSelectListItems
        {
            get
            {
                List<SelectListItem> items = new List<SelectListItem>();
                foreach (var workDone in workDones)
                {
                    items.Add(new SelectListItem
                    {
                        Text = workDone.ClientName + ' ' + workDone.WorkTypeName,
                        Value = workDone.Id.ToString()
                    });
                }
                return items;
            }
        }
    }

}