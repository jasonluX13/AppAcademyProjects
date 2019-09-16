using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvoiceMaker.Models
{
    public class WorkDone
    {
        public WorkDone(Client client, WorkType worktype)
        {
            this.client = client;
            this.workType = worktype;
            StartedOn = DateTimeOffset.Now;
        }

        public WorkDone(Client client, WorkType worktype, DateTimeOffset startedOn)
        {
            this.client = client;
            this.workType = worktype;
            StartedOn = startedOn;
        }

        public WorkDone(Client client, WorkType worktype, DateTimeOffset startedOn, DateTimeOffset endedOn)
        {
            this.client = client;
            this.workType = worktype;
            StartedOn = startedOn;
            EndedOn = endedOn;
        }

        public string ClientName {
            get
            {
                return client.Name;
            }
        }

        public string WorkTypeName
        {
            get
            {
                return workType.Name;
            }
        }
        public void Finished()
        {
            if (!EndedOn.HasValue)
            {
                EndedOn = DateTimeOffset.Now;
            }
        }

        public decimal? GetTotal()
        {
            if (EndedOn.HasValue)
            {
                decimal? hours = (decimal) (EndedOn.Value - StartedOn).TotalHours;
                return hours * workType.Rate;
            }
            return null;
        }
        private Client client { get; set; }
        private WorkType workType { get; set; }

        public DateTimeOffset StartedOn { get; private set; }
        public DateTimeOffset? EndedOn { get; private set; }
    }
}