using HsrTech.Context;
using HsrTech.Domain.Entities;
using HsrTech.Domain.Entities.Partial;
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
        public Statistics GetStatisticsByLogin(string login, StatisticsOptions options)
        {
            using (var context = new HsrTechContext())
            {
                HsrTechADO connection = new HsrTechADO(context.Database.Connection.ConnectionString);
                var clientId = getClientIdByLogin(login, connection);

                var select = $@"
                    COUNT(*) AS 'Count',
                    DATEPART(YEAR, OpenDate) AS 'Year',
                    DATEPART(MONTH, OpenDate) AS 'Month',
                    DATEPART(DAY, OpenDate) AS 'Day',
                    DATEPART(HOUR, OpenDate) AS 'Hour',
                    DATEPART(MINUTE, OpenDate) AS 'Minute',
                    DATEPART(SECOND, OpenDate) AS 'Second'
                ";

                var groupby = $@"
                    DATEPART(Second, OpenDate),
                    DATEPART(Minute, OpenDate),
                    DATEPART(Hour, OpenDate),
                    DATEPART(DAY, OpenDate),
                    DATEPART(MONTH, OpenDate),
                    DATEPART(YEAR, OpenDate)
                ";

                var orderby = $@" 'Year', 'Month', 'Day', 'Hour', 'Minute', 'Second' ";

                var data = connection.ExecuteQuery
                ($@" SELECT {select} FROM BankAccount WHERE ClientId = {clientId} GROUP BY {groupby} ORDER BY {orderby}");

                List<StatisticsItem> listItems = new List<StatisticsItem>();
                foreach (var item in data)
                {
                    var property = item as Dictionary<string, object>;
                    StatisticsItem statistic = new StatisticsItem(
                        int.Parse(property.ValueAsString("Year")),
                        int.Parse(property.ValueAsString("Month")),
                        int.Parse(property.ValueAsString("Day")),
                        int.Parse(property.ValueAsString("Hour")),
                        int.Parse(property.ValueAsString("Minute")),
                        int.Parse(property.ValueAsString("Second")),
                        int.Parse(property.ValueAsString("Count"))
                    );

                    listItems.Add(statistic);
                }
                return new Statistics(options, listItems);
            }
        }

        private int getClientIdByLogin(string login, HsrTechADO connection)
        {
            var data = connection.ExecuteQuery
            ($@"
                select  ClientId 
                from    Client
                where   Login = '{login}'
            ");

            var property = data[0] as Dictionary<string, object>;
            return int.Parse(property.ValueAsString("ClientId"));
        }





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
                    insert into BankAccount (OpenDate,Balance,ClientId,Limit) values (Getdate(),{balance.ToString().Replace(",", ".")},{clientID},{limit})
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
                    HsrTechADO connection = new HsrTechADO(context.Database.Connection.ConnectionString);
                    var query = connection.ExecuteQuery
                    ($@"
                        select  ClientId 
                        from    Client
                        where   Login = '{login}'
                    ");

                    var property = query[0] as Dictionary<string, object>;
                    int clientID = int.Parse(property.ValueAsString("ClientId"));

                    var query2 = connection.ExecuteQuery
                    ($@"
                        select  Balance
                        from    BankAccount
                        where   NumberAccount = {userNumberAccount}
                    ");

                    var property2 = query2[0] as Dictionary<string, object>;
                    decimal balanceUser = property2.ValueAsDecimal("Balance");

                    if ((balanceUser - value) <= 0)
                    {
                        return false;
                    }
                    else
                    {
                        
                        var update = connection.ExecuteQuery
                        ($@"
                            begin tran
                                update BankAccount set Balance = {(balanceUser - value).ToString().Replace(",", ".")} where ClientId = {clientID} and NumberAccount = {userNumberAccount}
                                update BankAccount set Balance = balance  + {(value).ToString().Replace(",", ".")} where ClientId = {clientID} and NumberAccount = {numberAccount}
                                insert into HistoricalTransaction (NumberAccount,Date,Value,FlagTransaction) values ({userNumberAccount},Getdate(),{value.ToString().Replace(",", ".")},1);
                            commit
                        ");
                        
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
