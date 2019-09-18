using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InvoiceMaker.Models
{
    public class WorkDone
    {
        public WorkDone()
        {

        }
        public WorkDone(int id, Client client, WorkType worktype)
        {
            this.Id = id;
            this.client = client;
            this.workType = worktype;
            StartedOn = DateTimeOffset.Now;
        }

        public WorkDone(int id, Client client, WorkType worktype, DateTimeOffset startedOn)
        {
            this.Id = id;
            this.client = client;
            this.workType = worktype;
            StartedOn = startedOn;
        }

        public WorkDone(int id, Client client, WorkType worktype, DateTimeOffset startedOn, DateTimeOffset? endedOn)
        {
            this.Id = id;
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
                decimal hours = (decimal) (EndedOn.Value - StartedOn).TotalHours;
                return decimal.Round(hours * workType.Rate,2);
            }
            return null;
        }
        
        public int GetClientId()
        {
            return client.Id;
        } 
        public int GetWorkTypeId()
        {
            return workType.Id;
        }

        private Client client { get; set; }
        private WorkType workType { get; set; }

        public int Id { get; set; }
        public DateTimeOffset StartedOn { get; set; }
        public DateTimeOffset? EndedOn { get; set; }
    }
}