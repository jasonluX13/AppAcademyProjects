﻿using InvoiceMaker.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace InvoiceMaker.Data
{
    public class Context : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<WorkType> WorkTypes { get; set; }
        public DbSet<WorkDone> WorkDones { get; set; }
        public DbSet<WorkLineItem> WorkLineItems { get; set; } 
        public DbSet<FeeLineItem> FeeLineItems { get; set; }
        public DbSet<Invoice> Invoices { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<WorkType>().Property(wt => wt.Rate).HasPrecision(18, 2);

            //modelBuilder.Entity<WorkDone>()
            //    .HasRequired(wd => wd.Client)
        }
    }
}