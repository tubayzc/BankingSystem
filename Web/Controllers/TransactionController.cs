using Business.Models.Request.Create;
using Business.Models.Request.Update;
using Business.Models.Response;
using Business.Services;
using Business.Services.Base.Interface;
using Business.Services.Interface;
using Core.Constants;
using Core.Results;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;
using Web.Controllers.Base;


namespace Web.Controllers
{
    public class TransactionController : BaseCRUDController<Transaction, int, CreateTransactionDto, TransactionUpdateDto, TransactionInfoDto>
    {
        private readonly TransactionService _transactionService;
        public TransactionController(IBaseService<Transaction, int, TransactionInfoDto> service, TransactionService transactionService) : base(service)
        {
           _transactionService = transactionService;
        }
        [HttpPost]
        public async Task<Result> TransferTransaction([FromBody]TransactionInfoDto transactiondto)
        {
            try
            {
                await _transactionService.Transfer(transactiondto);
                return new Result(Messages.Success, ResultStatus.Ok);
            }
            catch (Exception)
            {
                return new Result(Messages.Error, ResultStatus.Error);
            }

        }
    }
    
}
