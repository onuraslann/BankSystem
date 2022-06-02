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
    public class CreditConfiguration : IEntityTypeConfiguration<Credit>
    {
        public void Configure(EntityTypeBuilder<Credit> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.MinBudget).IsRequired();
            builder.Property(x => x.MaxBudget).IsRequired();
            builder.Property(x => x.MinLoanterm).IsRequired();
            builder.Property(x => x.MaxLoanterm).IsRequired();
            builder.Property(x => x.InterestRate).IsRequired();
        }
    }
}
