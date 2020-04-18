using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessCsvProvider
{
    public class DomainModelCsvContext : DbContext
    {
        //public DomainModelCsvContext(DbContextOptions<DomainModelCsvContext> options) : base(options)
        //{ }

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
