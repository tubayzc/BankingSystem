using Infrastructure.Data.Postgres.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Postgres.EntityFramework.Configurations
{
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.SenderAccountId).IsRequired();
            builder.Property(x => x.ReceiverAccountId).IsRequired();
            builder.Property(x => x.TransactionType).IsRequired();
            builder.Property(x => x.TransactionDate).IsRequired();
            builder.Property(x => x.Amount).IsRequired();

            builder.HasOne(t => t.SenderAccount)
            .WithMany(a => a.Transactions) 
            .HasForeignKey(t => t.SenderAccountId);

            
        }
    }
}

