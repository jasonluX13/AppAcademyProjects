using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace InvoiceMaker.Models
{
    public class WorkDone
    {
        public WorkDone()
        {

        }
        public WorkDone(Client client, WorkType worktype)
        {
            this.Client = client;
            this.WorkType = worktype;
            ClientId = Client.Id;
            WorkTypeId = WorkType.Id;
            StartedOn = DateTimeOffset.Now;
        }

        public WorkDone(int id, Client client, WorkType worktype)
        {
            this.Id = id;
            this.Client = client;
            this.WorkType = worktype;
            ClientId = Client.Id;
            WorkTypeId = WorkType.Id;
            StartedOn = DateTimeOffset.Now;
        }

        public WorkDone(int id, Client client, WorkType worktype, DateTimeOffset startedOn)
        {
            this.Id = id;
            this.Client = client;
            this.WorkType = worktype;
            ClientId = Client.Id;
            WorkTypeId = WorkType.Id;
            StartedOn = startedOn;
        }

        public WorkDone(Client client, WorkType worktype, DateTimeOffset startedOn, DateTimeOffset? endedOn)
        {
            this.Client = client;
            this.WorkType = worktype;
            ClientId = Client.Id;
            WorkTypeId = WorkType.Id;
            StartedOn = startedOn;
            EndedOn = endedOn;
        }

        public WorkDone(int id, Client client, WorkType worktype, DateTimeOffset startedOn, DateTimeOffset? endedOn)
        {
            this.Id = id;
            this.Client = client;
            this.WorkType = worktype;
            ClientId = Client.Id;
            WorkTypeId = WorkType.Id;
            StartedOn = startedOn;
            EndedOn = endedOn;
        }


        public string ClientName {
            get
            {
                return Client.Name;
            }
        }

        public string WorkTypeName
        {
            get
            {
                return WorkType.Name;
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
                return decimal.Round(hours * WorkType.Rate,2);
            }
            return null;
        }
        
        public int GetClientId()
        {
            return Client.Id;
        } 
        public int GetWorkTypeId()
        {
            return WorkType.Id;
        }

     
        public int ClientId { get; set; }
        public Client Client { get; set; }
    

        public int WorkTypeId { get; set; }
        public WorkType WorkType { get; set; }

        public int Id { get; set; }
        public DateTimeOffset StartedOn { get; set; }
        public DateTimeOffset? EndedOn { get; set; }
    }
}