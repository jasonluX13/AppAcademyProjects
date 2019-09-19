using InvoiceMaker.Data;
using InvoiceMaker.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace InvoiceMaker.Repositories
{
    public class WorkDoneRepository
    {
        private Context context;
        private DbSet<Client> clients;
        private DbSet<WorkType> workTypes;

        public WorkDoneRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["InvoiceMaker"].ConnectionString;
        }
        public WorkDoneRepository(Context context)
        {
            this.context = context;
            clients = context.Clients;
            workTypes = context.WorkTypes;
        }

        public List<WorkDone> GetAll()
        {

            return context.WorkDones
                .Include(wd => wd.Client)
                .Include(wd => wd.WorkType)
                .ToList();
        }

        public void Insert(WorkDone workDone)
        {
            context.WorkDones.Add(workDone);
            context.SaveChanges();
        }
        public void Update(WorkDone workDone)
        {
            context.WorkDones.Attach(workDone);
            context.Entry(workDone).State = EntityState.Modified;
            context.SaveChanges();
        }

        public WorkDone GetById(int id)
        {
            return context.WorkDones
                .Include(wd => wd.Client)
                .Include(wd => wd.WorkType)
                .SingleOrDefault(wd => wd.Id == id);
        }

        private string _connectionString;
    }
}