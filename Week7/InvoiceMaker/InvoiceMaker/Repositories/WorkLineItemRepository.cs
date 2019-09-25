using InvoiceMaker.Data;
using InvoiceMaker.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace InvoiceMaker.Repositories
{
    public class WorkLineItemRepository
    {

        private Context context;
        public WorkLineItemRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["InvoiceMaker"].ConnectionString;
        }

        public WorkLineItemRepository(Context context)
        {
            this.context = context;
        }

        public void Insert(WorkLineItem workLineItem)
        {
            context.WorkLineItems.Add(workLineItem);
            context.SaveChanges();
        }

        public List<WorkLineItem> GetWorkLineItems()
        {
            return context.WorkLineItems
                .Include(wli => wli.WorkDone)
                .Include(wli => wli.WorkDone.WorkType)
                .ToList();
        }


        private string _connectionString;
    }
}