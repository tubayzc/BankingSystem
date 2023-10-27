using Infrastructure.Data.Postgres.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models.Response
{
    public class AccountInfoDto
    {
        public int UserId { get; set; }

        public decimal Balance { get; set; }

        public string AccountType { get; set; }

        public string AccountNumber { get; set; }
        public User User { get; set; }
    }
}
