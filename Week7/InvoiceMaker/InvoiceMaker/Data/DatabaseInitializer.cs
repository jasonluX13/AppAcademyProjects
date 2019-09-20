using InvoiceMaker.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace InvoiceMaker.Data
{
    public class DatabaseInitializer : DropCreateDatabaseAlways<Context>
    {
        protected override void Seed(Context context)
        {
            var bob = new Client()
            {
                Name = "Bob",
                IsActive = true
            };

            var companyA = new Client()
            {
                Name = "CompanyA",
                IsActive = true
            };

            context.Clients.Add(bob);
            context.Clients.Add(companyA);

            context.Clients.Add(new Client()
            {
                Name = "Tom",
                IsActive = true
            });

            var createWebsite = new WorkType()
            {
                Name = "Create Website",
                Rate = 19.20M
            };

            var writeProposal = new WorkType()
            {
                Name = "Write proposal",
                Rate = 15.30M
            };

            context.WorkTypes.Add(createWebsite);
            context.WorkTypes.Add(writeProposal);
            context.WorkTypes.Add(new WorkType()
            {
                Name = "Create Invoice Maker",
                Rate = 15.00M
            });

            WorkDone bobWebsite = new WorkDone(bob, createWebsite);
            context.WorkDones.Add(bobWebsite);
            context.WorkDones.Add(new WorkDone(companyA, createWebsite));
            context.WorkDones.Add(new WorkDone(companyA, writeProposal));

            WorkLineItem wli = new WorkLineItem()
            {
                WorkDone = bobWebsite,
                InvoiceId = 1
            };
            context.WorkLineItems.Add(wli);

            Invoice bobInvoice = new Invoice("1234567890", bob);


            context.Invoices.Add(bobInvoice);

            context.SaveChanges();
        }
    }
}