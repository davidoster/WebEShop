namespace WebEShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerProductAddedCategoryNavigationAndChangesMaybeToProductCategory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustomerProducts", "Category_Id", c => c.Int());
            CreateIndex("dbo.CustomerProducts", "Category_Id");
            AddForeignKey("dbo.CustomerProducts", "Category_Id", "dbo.ProductCategories", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomerProducts", "Category_Id", "dbo.ProductCategories");
            DropIndex("dbo.CustomerProducts", new[] { "Category_Id" });
            DropColumn("dbo.CustomerProducts", "Category_Id");
        }
    }
}
