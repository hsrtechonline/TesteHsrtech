namespace HsrTech.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Base : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Bank_Accont", newName: "Bank_Account");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Bank_Account", newName: "Bank_Accont");
        }
    }
}
