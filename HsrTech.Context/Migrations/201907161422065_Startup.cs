namespace HsrTech.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Startup : DbMigration
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
                .PrimaryKey(t => t.NumberAccount)
                .ForeignKey("dbo.Client", t => t.ClientId, cascadeDelete: true)
                .Index(t => t.ClientId);
            
            CreateTable(
                "dbo.HistoricalTransaction",
                c => new
                    {
                        HistoricalTransactionId = c.Int(nullable: false, identity: true),
                        NumberAccount = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Value = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FlagTransaction = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.HistoricalTransactionId)
                .ForeignKey("dbo.BankAccount", t => t.NumberAccount, cascadeDelete: true)
                .Index(t => t.NumberAccount);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BankAccount", "ClientId", "dbo.Client");
            DropForeignKey("dbo.HistoricalTransaction", "NumberAccount", "dbo.BankAccount");
            DropIndex("dbo.HistoricalTransaction", new[] { "NumberAccount" });
            DropIndex("dbo.BankAccount", new[] { "ClientId" });
            DropTable("dbo.Client");
            DropTable("dbo.HistoricalTransaction");
            DropTable("dbo.BankAccount");
        }
    }
}
