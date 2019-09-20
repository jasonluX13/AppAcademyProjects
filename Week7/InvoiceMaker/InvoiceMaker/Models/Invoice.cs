using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvoiceMaker.Models
{
    public class Invoice
    {
        public Invoice()
        {
            LineItems = new List<ILineItem>();
        }

        public Invoice(string invoiceNumber, Client client)
        {
            InvoiceNumber = invoiceNumber;
            LineItems = new List<ILineItem>();
            Status = InvoiceStatus.Open;
            Client = client;
        }

        public Invoice(string invoiceNumber, InvoiceStatus status, Client client)
            : this(invoiceNumber, client)
        {
            Status = status;
        }

        public void FinalizeInvoice()
        {
            if (Status == InvoiceStatus.Open)
            {
                Status = InvoiceStatus.Finalized;
            }
        }

        public void CloseInvoice()
        {
            if (Status == InvoiceStatus.Finalized)
            {
                Status = InvoiceStatus.Closed;
            }
        }

        public void AddWorkLineItem(WorkDone workDone)
        {
            //LineItems.Add(new WorkLineItem(workDone));
        }

        public void AddFeeLineItem(string description, decimal amount, DateTimeOffset when)
        {
            LineItems.Add(new FeeLineItem(description, amount, when));
        }

        public int Id { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }

        public InvoiceStatus Status { get; set; }
        public string InvoiceNumber { get; set; }
        public List<ILineItem> LineItems { get; set; }
    }
}