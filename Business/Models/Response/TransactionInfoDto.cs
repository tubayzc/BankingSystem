using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models.Response
{
    public class TransactionInfoDto
    {
        public string TransactionType { get; set; }

        public decimal Amount { get; set; }

        public int SenderAccountId { get; set; }

        public int ReceiverAccountId { get; set; }

    }
}
