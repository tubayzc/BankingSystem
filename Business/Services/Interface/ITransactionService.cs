using Business.Models.Response;
using Business.Services.Base.Interface;
using Infrastructure.Data.Postgres.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Business.Services.Interface
{
    public interface ITransactionService : IBaseService<Transaction, int, TransactionInfoDto>
    {
        public Task Transfer(TransactionInfoDto transaction);
    }
}
