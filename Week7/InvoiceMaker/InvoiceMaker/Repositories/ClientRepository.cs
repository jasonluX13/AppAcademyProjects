using InvoiceMaker.Data;
using InvoiceMaker.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;

namespace InvoiceMaker.Repositories
{
    public class ClientRepository
    {
        private Context context;
        public ClientRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["InvoiceMaker"].ConnectionString;
        }
        public ClientRepository(Context context)
        {
            this.context = context;
        }

        public List<Client> GetClients()
        {
            return context.Clients.ToList();
        }
        public void Insert(Client client)
        {
            context.Clients.Add(client);
            context.SaveChanges();
        }

        public void Update(Client client)
        {
            context.Clients.Attach(client);
            context.Entry(client).State = EntityState.Modified;
            context.SaveChanges();
        }

        public Client GetById(int id)
        {
            return context.Clients.SingleOrDefault(c => c.Id == id);

        }
        private string _connectionString;
    }
}
