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
    public class Account :Entity<int>
    {

        public int UserId { get; set; }

        public decimal Balance { get; set; }

        public string AccountType { get; set; }

        public string AccountNumber { get; set; }

        public virtual User User { get; set; }

        public virtual List<Transaction> Transactions { get; set; }
    }
}
