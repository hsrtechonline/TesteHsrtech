namespace HsrTech.Context.Migrations
{
    using HsrTech.Domain.Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<HsrTechContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(HsrTechContext context)
        {
            context.Client.Add(new Client() {
                ClientId = 1,
                Name = "Admin",
                Login = "admin",
                Password = "admin"
            });

            List<BankAccount> accounts = new List<BankAccount>();
            Random r = new Random();
            for(int i = 1; i <= 20; i++)
            {
                accounts.Add(new BankAccount()
                {
                    NumberAccount = i,
                    OpenDate = new DateTime(2019, 10, r.Next(1, 28), r.Next(0, 23), r.Next(0, 59), r.Next(0, 59)),
                    Balance = 1000,
                    ClientId = 1,
                    Limit = 1000
                });
            }
            context.BankAccount.AddRange(accounts);
        }
    }
}