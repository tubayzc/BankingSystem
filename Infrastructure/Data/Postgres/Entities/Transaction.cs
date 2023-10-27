using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Data.Postgres.Entities.Base;

namespace Infrastructure.Data.Postgres.Entities
{
    public class Transaction: Entity<int>
    {       
        
        public string TransactionType { get; set; }

        public DateTime TransactionDate { get; set; }

        public decimal Amount { get; set; }

        public int SenderAccountId { get; set; }

        public int ReceiverAccountId { get; set; }

        [ForeignKey("SenderAccountId")]
        public virtual Account SenderAccount { get; set; }

        [ForeignKey("ReceiverAccountId")]
        public virtual Account ReceiverAccount { get; set;}

    }
}
