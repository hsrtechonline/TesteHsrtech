using HsrTech.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HsrTech.Context
{
    class BankInitializer : DropCreateDatabaseAlways<HsrTechContext>
    {
        protected override void Seed(HsrTechContext context)
        {
            base.Seed(context);

            context.Client.Add(
                new Client
                {
                    ClientId = 1,
                    Login = "flpinheiro" ,
                    Password = "12345678",
                    Name = "Felipe Luís Pinheiro"
                });
            context.BankAccount.AddRange(
                new List<BankAccount>
                {
                    new BankAccount
                    {
                        ClientId = 1,
                        Balance = 1000 ,
                        Limit = 500,
                        NumberAccount = 1,
                        OpenDate = DateTime.Today
                    }, 
                    new BankAccount
                    {
                        ClientId = 1,
                        Balance = 2000,
                        Limit = 1000,
                        NumberAccount = 2,
                        OpenDate = DateTime.Today.AddDays(1)
                    }
                });

            context.HistoricalTransaction.AddRange(
                new List<HistoricalTransaction>
                {
                    new HistoricalTransaction
                    {
                        NumberAccount = 1,
                        Date = DateTime.Today,
                        FlagTransaction = true
                    },
                    new HistoricalTransaction
                    {
                        NumberAccount = 2,
                        Date = DateTime.Today.AddDays(1),
                        FlagTransaction = false
                    }
                });
        }
    }
}
