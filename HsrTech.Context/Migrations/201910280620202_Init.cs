namespace HsrTech.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BankAccount",
                c => new
                    {
                        NumberAccount = c.Int(nullable: false, identity: true),
                        OpenDate = c.DateTime(nullable: false),
                        Balance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ClientId = c.Int(nullable: false),
                        Limit = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.NumberAccount);
            
            CreateTable(
                "dbo.Client",
                c => new
                    {
                        ClientId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Login = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.ClientId);
            
            CreateTable(
                "dbo.HistoricalTransactions",
                c => new
                    {
                        HistoricalTransactionId = c.Int(nullable: false, identity: true),
                        NumberAccount = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Value = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FlagTransaction = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.HistoricalTransactionId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.HistoricalTransactions");
            DropTable("dbo.Client");
            DropTable("dbo.BankAccount");
        }
    }
}
