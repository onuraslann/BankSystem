using Bank.Domain.General;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.DataAccess.EntityFramework.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.FirstName).HasMaxLength(50);
            builder.Property(x => x.FirstName).IsRequired();
            builder.Property(x => x.LastName).HasMaxLength(50);
            builder.Property(x => x.Tckn).IsRequired();
            builder.Property(x => x.Gender).IsRequired();
            builder.Property(x => x.Age).IsRequired();
           
        }
    }
}
