using Infrastructure.Data.Postgres.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace Infrastructure.Data.Postgres.Entities;

public class User : Entity<int>
{
    public string UserName { get; set; }
    public string Email { get; set; } = default!;
    public string FullName { get; set; } = default!;
    public byte[] PasswordSalt { get; set; } = default!;
    public byte[] PasswordHash { get; set; } = default!;

    public string PhoneNumber { get; set; }
    public Account Account { get; set; }

    public UserType Role { get; set; }
    //Diğer tabloları çağırdık.
    public virtual List<Account> Accounts { get; set; }
    public virtual List<Transaction> Transactions { get; set; }
    public virtual List<Transaction> SentTransactions { get; set; } // Gönderen işlemler
    public virtual List<Transaction> ReceivedTransactions { get; set; } // Alıcı işlemler

    


    public enum UserType
    {
        Admin,
        User, //Customer
        Employee,
    }
}