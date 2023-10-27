using Business.Models.Response;
using Business.Services.Base;
using Business.Services.Interface;
using Business.Utilities.Mapping.Interface;
using Core.Results;
using Infrastructure.Data.Postgres;
using Infrastructure.Data.Postgres.Entities;
using Infrastructure.Data.Postgres.Repositories.Base.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class TransactionService : BaseService<Transaction, int, TransactionInfoDto>, ITransactionService
    {
        private readonly IUnitOfWork _unitOfWork;
        public TransactionService(IUnitOfWork unitOfWork, IRepository<Transaction, int> repository, IMapperHelper mapperHelper) : base(unitOfWork, repository, mapperHelper)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task Transfer(TransactionInfoDto transaction)
        {
             var senderUser = await _unitOfWork.Users
                .GetAsync(u => u.Accounts.Any(a => a.Id == transaction.SenderAccountId));

            var receiverUser = await _unitOfWork.Users
               .GetAsync(u => u.Accounts.Any(a => a.Id == transaction.ReceiverAccountId));

            if(senderUser == null || receiverUser == null)
            {
                throw new Exception("User not found!");
            }

            if (senderUser.Account.Balance < transaction.Amount) 
            {
                throw new Exception("Your money is not enough for this transfer!");
            }
            
            senderUser.Account.Balance = senderUser.Account.Balance - transaction.Amount;
            receiverUser.Account.Balance = receiverUser.Account.Balance + transaction.Amount;

            var trans= new Transaction { 
                Amount= transaction.Amount,
                SenderAccountId= transaction.SenderAccountId,
                ReceiverAccountId= transaction.ReceiverAccountId,
                TransactionDate = DateTime.Now
            };
            await _unitOfWork.CommitAsync();

        }



    }
}
