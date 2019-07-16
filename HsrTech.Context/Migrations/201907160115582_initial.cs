namespace HsrTech.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BankAccounts",
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
                "dbo.Clients",
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
                        NumberAccount = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Value = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FlagTransaction = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.NumberAccount);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.HistoricalTransactions");
            DropTable("dbo.Clients");
            DropTable("dbo.BankAccounts");
        }
    }
}
