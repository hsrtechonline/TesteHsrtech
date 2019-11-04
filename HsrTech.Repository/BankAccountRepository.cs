using HsrTech.Context;
using HsrTech.Domain.Entities;
using HsrTech.Domain.Interface.Repository;
using HsrTech.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HsrTech.Repository
{
    public class BankAccountRepository : RepositoryBase<BankAccount>, IBankAccountRepository
    {
        
        public void CreateAccount(decimal balance, int limit, string login)
        {
            using (var context = new HsrTechContext())
            {
                HsrTechADO connection = new HsrTechADO(context.Database.Connection.ConnectionString);
                var data = connection.ExecuteQuery
                ($@"
                    select  ClientId 
                    from    Client
                    where   Login = '{login}'
                ");

                var property = data[0] as Dictionary<string, object>;
                int clientID = int.Parse(property.ValueAsString("ClientId"));

                var insertAccount = connection.ExecuteQuery
                ($@"
                    insert into BankAccount (OpenDate,Balance,ClientId,Limit) values ('{DateTime.Now.ToString("dd/MM/yyyy HH:mm")}',{balance.ToString().Replace(",", ".")},{clientID},{limit})
                ");
            }
        }

        public BankAccount GetAccountByNumberAccount(int numberAccount)
        {
            using (var context = new HsrTechContext())
            {
                HsrTechADO connection = new HsrTechADO(context.Database.Connection.ConnectionString);
                var data = connection.ExecuteQuery
                ($@"
                        select	t1.*
                        from	BankAccount t1                        
                        where	t1.NumberAccount = {numberAccount}
                    ");

                var property = data[0] as Dictionary<string, object>;
                BankAccount account = new BankAccount()
                {
                    Balance = Convert.ToDecimal(property.ValueAsDecimal("Balance")),
                    ClientId = int.Parse(property.ValueAsString("ClientId")),
                    Limit = int.Parse(property.ValueAsString("Limit")),
                    NumberAccount = int.Parse(property.ValueAsString("NumberAccount")),
                    OpenDate = Convert.ToDateTime(property.ValueAsDateTimeNullable("OpenDate"))

                };
                return account;
            }
        }

        public IList<BankAccount> ListAccountsByLogin(string login)
        {
            using (var context = new HsrTechContext())
            {
                HsrTechADO connection = new HsrTechADO(context.Database.Connection.ConnectionString);
                var data = connection.ExecuteQuery
                    ($@"
                        select	t1.*
                        from	BankAccount t1
                        inner	join Client t2
                        on		t1.ClientId = t2.ClientId
                        where	t2.Login = '{login}'
                    ");
                List<BankAccount> listAccounts = new List<BankAccount>();
                foreach (var item in data)
                {
                    var property = item as Dictionary<string, object>;
                    BankAccount account = new BankAccount()
                    {
                        Balance = Convert.ToDecimal(property.ValueAsDecimal("Balance")),
                        ClientId = int.Parse(property.ValueAsString("ClientId")),
                        Limit = int.Parse(property.ValueAsString("Limit")),
                        NumberAccount = int.Parse(property.ValueAsString("NumberAccount")),
                        OpenDate = Convert.ToDateTime(property.ValueAsDateTimeNullable("OpenDate"))

                    };

                    listAccounts.Add(account);
                }
                return listAccounts;
            }
        }

        public bool Transfer(decimal value, int numberAccount, int typeTransfer, string login, int userNumberAccount)
        {
            
            try
            {
                using (var context = new HsrTechContext())
                {
                    decimal valorDisponivel;

                    HsrTechADO connection = new HsrTechADO(context.Database.Connection.ConnectionString);
                    var query = connection.ExecuteQuery
                            ($@"
                                select  ClientId 
                                from    Client
                                where   Login = '{login}'
                            ");
                    var property = query[0] as Dictionary<string, object>;
                    int clientID = int.Parse(property.ValueAsString("ClientId"));


                    //CONTA REMETENTE
                    var query2 = connection.ExecuteQuery
                                    ($@"
                                select  Balance, Limit 
                                from    BankAccount
                                where   NumberAccount = {userNumberAccount}
                                ");

                    var property2 = query2[0] as Dictionary<string, object>;
                    decimal balanceUser = property2.ValueAsDecimal("Balance");
                    decimal limiteUser = property2.ValueAsDecimal("Limit");

                    //CONTA DESTINO
                    var queryAccountTarget = connection.ExecuteQuery
                                    ($@"
                                select  Balance, Limit 
                                from    BankAccount
                                where   NumberAccount = {numberAccount}
                                ");

                    var property3 = queryAccountTarget[0] as Dictionary<string, object>;
                    decimal balanceUsertarget = property3.ValueAsDecimal("Balance");
                    decimal limiteUsertarget = property3.ValueAsDecimal("Limit");

                    if (typeTransfer == 0)
                        valorDisponivel = balanceUser;
                    else
                        valorDisponivel = limiteUser;
                    

                    if ((valorDisponivel - value) < 0)
                    {
                        return false;
                    }
                    else
                    {
                        //se for Conta corrente,  altera o Balance
                        if(typeTransfer == 0)
                        {
                            var update = connection.ExecuteQuery
                            ($@"
                                begin tran
                                    update BankAccount set Balance = {(balanceUser - value).ToString().Replace(",", ".")} where ClientId = {clientID} and NumberAccount = {userNumberAccount} ;
                                    update BankAccount set Balance = {(balanceUsertarget + value).ToString().Replace(",", ".")} where ClientId = {numberAccount} and NumberAccount = {numberAccount}
                                    insert into HistoricalTransaction (NumberAccount,NumberAccountTarget,Date,Value,FlagTransaction) values ({userNumberAccount},{numberAccount},'{DateTime.Now.ToString("dd/MM/yyyy HH:mm")}','{value.ToString().Replace(",", ".")}',{typeTransfer});
                                commit
                            ");
                        }
                        //Caso for credito, altera o limite
                        else
                        {
                            var update = connection.ExecuteQuery
                            ($@"
                                begin tran
                                    update BankAccount set Limit = {(limiteUser - value).ToString().Replace(",", ".")} where ClientId = {clientID} and NumberAccount = {userNumberAccount} ;
                                    update BankAccount set Limit = {(limiteUsertarget + value).ToString().Replace(",", ".")} where ClientId = {numberAccount} and NumberAccount = {numberAccount}
                                    insert into HistoricalTransaction (NumberAccount,NumberAccountTarget,Date,Value,FlagTransaction) values ({userNumberAccount},{numberAccount},'{DateTime.Now.ToString("dd/MM/yyyy HH:mm")}','{value.ToString().Replace(",", ".")}',{typeTransfer});
                                commit
                            ");
                        }
                        
                        
                            
                    }
                }
                return true;

            }
            catch (Exception ex)
            {

                return false;
            }
        }
    }
}
