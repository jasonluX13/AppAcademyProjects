using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvoiceMaker.Models
{
    public class FeeLineItem : ILineItem
    {
        public FeeLineItem()
        {

        }
        public FeeLineItem(string description, decimal amount, DateTimeOffset when)
        {
            Description = description;
            Amount = amount;
            When = when;
        }

        public decimal Amount { get; set; }
        public string Description { get; set; }     
        public DateTimeOffset When { get; set; }
   
        public int Id { get; set; }

        public int InvoiceId { get; set; }
    }
}