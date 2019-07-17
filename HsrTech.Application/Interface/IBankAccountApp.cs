﻿using HsrTech.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HsrTech.Domain.Entities.Partial;

namespace HsrTech.Application.Interface
{
    public interface IBankAccountApp : IAppBase<BankAccount>
    {
        IList<BankAccount> ListAccountsByLogin(string login);
        BankAccount GetAccountByNumberAccount(int numberAccount);
        void CreateAccount(decimal balance, int limit, string name);
        bool Transfer(decimal value, int numberAccount, int typeTransfer, string login, int userNumberAccount);
        IList<AccountCreation> GetAccountsCreated(DateTime? startDate, DateTime? endDate, int type);
    }
}
