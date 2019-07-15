namespace HsrTech.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bank_Accont",
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
                "dbo.Historical",
                c => new
                    {
                        NumberAccount = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Value = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FlagTransaction = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.NumberAccount, t.Date })
                .ForeignKey("dbo.Bank_Accont", t => t.NumberAccount, cascadeDelete: true)
                .Index(t => t.NumberAccount);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Historical", "NumberAccount", "dbo.Bank_Accont");
            DropForeignKey("dbo.Bank_Accont", "ClientId", "dbo.Client");
            DropIndex("dbo.Historical", new[] { "NumberAccount" });
            DropIndex("dbo.Bank_Accont", new[] { "ClientId" });
            DropTable("dbo.Historical");
            DropTable("dbo.Client");
            DropTable("dbo.Bank_Accont");
        }
    }
}
