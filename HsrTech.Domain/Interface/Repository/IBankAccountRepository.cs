using HsrTech.Domain.Entities;
using HsrTech.Domain.Entities.Partial;
using System.Collections.Generic;

namespace HsrTech.Domain.Interface.Repository
{
    public interface IBankAccountRepository : IRepositoryBase<BankAccount>
    {
        Statistics GetStatisticsByLogin(string login, StatisticsOptions options);
        IList<BankAccount> ListAccountsByLogin(string login);
        BankAccount GetAccountByNumberAccount(int numberAccount);
        void CreateAccount(decimal balance, int limit, string login);
        bool Transfer(decimal value, int numberAccount, int typeTransfer, string login, int userNumberAccount);
    }
}
