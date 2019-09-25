using InvoiceMaker.Data;
using InvoiceMaker.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace InvoiceMaker.Repositories
{
    public class WorkTypeRepository
    {
        private Context context;
        public WorkTypeRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["InvoiceMaker"].ConnectionString;
        }
        public WorkTypeRepository(Context context)
        {
            this.context = context;
        }

        public List<WorkType> GetWorkTypes()
        {
            return context.WorkTypes.ToList();
        }

        public WorkType GetById(int id)
        {
            return context.WorkTypes.SingleOrDefault(wt => wt.Id == id);

        }

        public void Insert(WorkType workType)
        {
            context.WorkTypes.Add(workType);
            context.SaveChanges();
        }

        public void Update(WorkType workType)
        {
            context.WorkTypes.Attach(workType);
            context.Entry(workType).State = EntityState.Modified;
            context.SaveChanges();
        }
        private string _connectionString;
    }
}