namespace WebEShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangesToCustomerProduct : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CustomerProducts", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.CustomerProducts", "Price", c => c.Decimal());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CustomerProducts", "Title", c => c.String());
        }
    }
}
