namespace dinner.net.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MealHistory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MealHistory",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        MealID = c.Int(nullable: false),
                        DateAte = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Meal", t => t.MealID, cascadeDelete: true)
                .Index(t => t.MealID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MealHistory", "MealID", "dbo.Meal");
            DropIndex("dbo.MealHistory", new[] { "MealID" });
            DropTable("dbo.MealHistory");
        }
    }
}
