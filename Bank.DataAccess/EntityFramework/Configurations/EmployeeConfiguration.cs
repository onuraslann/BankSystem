using Bank.Core.BaseRepository.Abstract;
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
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Property(e => e.FirstName).HasMaxLength(50);
            builder.Property(e => e.FirstName).IsRequired();
            builder.Property(e => e.LastName).HasMaxLength(50);
            builder.Property(e => e.Gender).IsRequired();
            builder.Property(e => e.Age).IsRequired();
        }
    }
}
