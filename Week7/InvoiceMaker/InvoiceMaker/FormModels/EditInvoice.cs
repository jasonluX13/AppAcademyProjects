using InvoiceMaker.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InvoiceMaker.FormModels
{
    public class EditInvoice
    {
        [Display(Name = "Client")]
        public int ClientId { get; set; }
        [Display(Name = "Invoice Number")]
        public string InvoiceNumber { get; set; }
        public List<ILineItem> LineItems { get; set; }

    }

    public class EditInvoiceView : EditInvoice
    {
        

        
    }
}