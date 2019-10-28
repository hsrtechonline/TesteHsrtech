using HsrTech.Domain.Entities;
using HsrTech.Domain.Entities.Partial;
using System.Collections.Generic;

namespace HsrTech.Application.Interface
{
    public interface IBankAccountApp : IAppBase<BankAccount>
    {
        Statistics GetStatisticsByLogin(string login, StatisticsOptions options);
        IList<BankAccount> ListAccountsByLogin(string login);
        BankAccount GetAccountByNumberAccount(int numberAccount);
        void CreateAccount(decimal balance, int limit, string name);
        bool Transfer(decimal value, int numberAccount, int typeTransfer, string login, int userNumberAccount);
    }
}
