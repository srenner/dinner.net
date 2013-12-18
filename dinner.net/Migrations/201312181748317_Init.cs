namespace dinner.net.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ingredient", "ExtendedDescription", c => c.String());
            AlterColumn("dbo.Ingredient", "Name", c => c.String(nullable: false, maxLength: 100));
            DropColumn("dbo.Ingredient", "Quantity");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Ingredient", "Quantity", c => c.Int(nullable: false));
            AlterColumn("dbo.Ingredient", "Name", c => c.String());
            DropColumn("dbo.Ingredient", "ExtendedDescription");
        }
    }
}
