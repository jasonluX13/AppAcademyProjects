using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvoiceMaker.Models
{
    public class WorkLineItem : ILineItem
    {
        public WorkLineItem(int id, WorkDone workDone)
        {
            this.Id = id;
            this.workDone = workDone;
        }
        public int Id { get; set; }
        public decimal Amount
        {
            get
            {
                decimal? total = workDone.GetTotal();
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
                return workDone.WorkTypeName;
            }
         }
        public DateTimeOffset When
        {
            get
            {

                return workDone.StartedOn;
            }

        }
        private WorkDone workDone { get; set; }
    }
}