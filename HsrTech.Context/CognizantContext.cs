using HsrTech.Context.Interface;
using HsrTech.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HsrTech.Context
{
    public class HsrTechContext : DbContext, IHsrTechContext
    {
        public HsrTechContext() : base(nameOrConnectionString: "Base")
        {
            Database.SetInitializer(new BankInitializer());
        }
        public DbSet<Client> Client { get; set; }
        public DbSet<BankAccount> BankAccount { get; set; }
        public DbSet<HistoricalTransaction> HistoricalTransaction { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region <pk>
            modelBuilder
                .Entity<Client>()
                .HasKey(c => c.ClientId);
            modelBuilder
                .Entity<BankAccount>()
                .HasKey(c => c.NumberAccount);
            modelBuilder
                .Entity<HistoricalTransaction>()
                .HasKey(c => new { c.NumberAccount, c.Date });
            #endregion

            #region <fk>
            modelBuilder
                .Entity<BankAccount>()
                .HasRequired(c => c.Client)
                .WithMany(c => c.BankAccounts)
                .HasForeignKey(c => c.ClientId);
            modelBuilder
                .Entity<HistoricalTransaction>()
                .HasRequired(c => c.BankAccounty)
                .WithMany(c => c.HistoricalTransactions)
                .HasForeignKey(c => c.NumberAccount);
            #endregion

            #region tables
            modelBuilder.Entity<Client>().ToTable("Client");
            modelBuilder.Entity<BankAccount>().ToTable("Bank_Account");
            modelBuilder.Entity<HistoricalTransaction>().ToTable("Historical");
            #endregion
        }
    }
}
