using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModelSqlServerProvider
{
    public class DomainModelSqlServerContext : DbContext
    {
     
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Person>().HasKey(m => m.Id);
            base.OnModelCreating(builder);
        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            return base.SaveChanges();
        }

    }
}
