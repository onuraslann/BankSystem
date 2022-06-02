using Bank.Domain.General;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.DataAccess.EntityFramework.Context
{
    public class BankContext:DbContext
    {

        public BankContext(DbContextOptions<BankContext> options):base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Credit> Credits { get; set; }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
