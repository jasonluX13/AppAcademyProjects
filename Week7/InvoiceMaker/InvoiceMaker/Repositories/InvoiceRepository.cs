using InvoiceMaker.Data;
using InvoiceMaker.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace InvoiceMaker.Repositories
{
    public class InvoiceRepository
    {
        private Context context;

        public InvoiceRepository(Context context)
        {
            this.context = context;
        }

        public Invoice GetById(int id)
        {
            Invoice invoice = context.Invoices
                .Include(i => i.Client)
                .SingleOrDefault(i => i.Id == id);
            List<WorkLineItem> workLineItems = context.WorkLineItems
                .Include(wli => wli.WorkDone.WorkType)
                .Where(wli => wli.InvoiceId == id)
                .ToList();
            List<FeeLineItem> feeLineItems = context.FeeLineItems
                .Where(fli => fli.InvoiceId == id)
                .ToList();
            foreach (var wli in workLineItems)
            {
                invoice.LineItems.Add(wli);
            }
            foreach(var fli in feeLineItems)
            {
                invoice.LineItems.Add(fli);
            }
            return invoice;
        }

        public List<Invoice> GetList()
        {
            return context.Invoices
                .Include(i => i.Client)
                .ToList();
        }

        public void Insert(Invoice invoice)
        {
            context.Invoices.Add(invoice);
            context.SaveChanges();
        }

    }
}