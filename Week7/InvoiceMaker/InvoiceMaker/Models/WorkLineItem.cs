using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvoiceMaker.Models
{
    public class WorkLineItem : ILineItem
    {
        public WorkLineItem()
        {

        }

        public WorkLineItem(int id, WorkDone workDone)
        {
            this.Id = id;
            this.WorkDone = workDone;
        }
        
        public decimal Amount
        {
            get
            {
                decimal? total = WorkDone.GetTotal();
                if (total.HasValue)
                {
                    return total.Value;
                }
                return 0;
            }
        }
        public string Description {
            get
            {
                return WorkDone.WorkTypeName;
            }
         }
        public DateTimeOffset When
        {
            get
            {

                return WorkDone.StartedOn;
            }

        }

        public int Id { get; set; }

        public int WorkDoneId { get; set; }
        public WorkDone WorkDone { get; set; }

        public int InvoiceId { get; set; }
    }
}