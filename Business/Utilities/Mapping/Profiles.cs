using Business.Models.Request.Create;
using Business.Models.Request.Functional;
using Business.Models.Request.Update;
using Business.Models.Response;
using Infrastructure.Data.Postgres.Entities;

namespace Business.Utilities.Mapping;

public class Profiles : AutoMapper.Profile
{
    public Profiles()
    {
        //User
        CreateMap<RegisterDto, User>();
        CreateMap<User, UserProfileDto>();
        CreateMap<UserUpdateDto, User>();
        CreateMap<ChangePasswordDto, User>();
        CreateMap<Account, CreateAccountDto>();
        CreateMap<AccountUpdateDto, Account>();
        CreateMap<Account, AccountInfoDto>();
        CreateMap<CreateTransactionDto, Transaction>();
        CreateMap<Transaction, TransactionInfoDto>();


    }
}