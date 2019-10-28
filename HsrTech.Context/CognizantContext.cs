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
        public HsrTechContext() : base(nameOrConnectionString: "Base"){}
        public DbSet<Client> Client { get; set; }
        public DbSet<BankAccount> BankAccount { get; set; }
        public DbSet<HistoricalTransaction> HistoricalTransaction { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BankAccount>().ToTable("BankAccount")
                .HasKey(b => b.NumberAccount);

            modelBuilder.Entity<Client>().ToTable("Client");
        }
    }
}
