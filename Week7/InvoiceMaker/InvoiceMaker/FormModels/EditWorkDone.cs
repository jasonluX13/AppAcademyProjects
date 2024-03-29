﻿using InvoiceMaker.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InvoiceMaker.FormModels
{

    public class EditWorkDone
    {
        public int Id { get; set; }
        [Display(Name = "Client")]
        public int ClientId { get; set; }
        [Display(Name = "WorkType")]
        public int WorkTypeId { get; set; }
        public DateTimeOffset StartedOn { get; set; }
        public DateTimeOffset? EndedOn { get; set; }
    }

    public class EditWorkDoneView : EditWorkDone
    {
        public List<Client> Clients { get; set; }
        public List<WorkType> WorkTypes { get; set; }

        public List<SelectListItem> ClientSelectListItems
        {
            get
            {
                List<SelectListItem> items = new List<SelectListItem>();
                foreach (var client in Clients)
                {
                    
                    if (client.Id == ClientId)
                    {
                        items.Add(new SelectListItem { Text = client.Name, Value = client.Id.ToString(), Selected = true });
                    }
                    else
                    {
                        items.Add(new SelectListItem { Text = client.Name, Value = client.Id.ToString() });
                    }
                }
                return items;
            }
        }

        public List<SelectListItem> WorkTypeSelectListItems
        {
            get
            {
                List<SelectListItem> items = new List<SelectListItem>();
                foreach (var workType in WorkTypes)
                {
                    if (workType.Id == WorkTypeId)
                    {
                        items.Add(new SelectListItem { Text = workType.Name, Value = workType.Id.ToString(), Selected = true });
                    }
                    else
                    {
                        items.Add(new SelectListItem { Text = workType.Name, Value = workType.Id.ToString() });
                    }
                    
                }
                return items;
            }
        }
    }
}