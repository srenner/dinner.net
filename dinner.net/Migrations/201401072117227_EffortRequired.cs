namespace dinner.net.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EffortRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Meal", "Effort", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Meal", "Effort", c => c.Int());
        }
    }
}
