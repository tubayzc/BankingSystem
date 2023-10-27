using Business.Models.Request.Create;
using Business.Models.Request.Update;
using Business.Models.Response;
using Business.Services.Base.Interface;
using Infrastructure.Data.Postgres.Entities;
using Web.Controllers.Base;

namespace Web.Controllers
{
    public class AccountController : BaseCRUDController<Account, int, CreateAccountDto, AccountUpdateDto, AccountInfoDto>
    {
        public AccountController(IBaseService<Account, int, AccountInfoDto> service) : base(service)
        {
        }
    }
}
