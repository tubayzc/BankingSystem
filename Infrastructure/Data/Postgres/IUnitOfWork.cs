using Infrastructure.Data.Postgres.Repositories.Interface;

namespace Infrastructure.Data.Postgres;

public interface IUnitOfWork : IDisposable
{
    IUserRepository Users { get; }
    IAccountRepository Accounts { get; }
    ITransactionRepository Transactions { get; }
    IUserTokenRepository UserTokens { get; }


    Task<int> CommitAsync();
}