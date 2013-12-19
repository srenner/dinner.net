namespace dinner.net.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RelationshipTest : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MealIngredient",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        MealID = c.Int(nullable: false),
                        IngredientID = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        QuantityDescription = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Ingredient", t => t.IngredientID, cascadeDelete: true)
                .ForeignKey("dbo.Meal", t => t.MealID, cascadeDelete: true)
                .Index(t => t.IngredientID)
                .Index(t => t.MealID);
            
            CreateTable(
                "dbo.Meal",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        ExtendedDescription = c.String(),
                        StepsToMake = c.String(),
                        Rating = c.Int(nullable: false),
                        LastAte = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MealIngredient", "MealID", "dbo.Meal");
            DropForeignKey("dbo.MealIngredient", "IngredientID", "dbo.Ingredient");
            DropIndex("dbo.MealIngredient", new[] { "MealID" });
            DropIndex("dbo.MealIngredient", new[] { "IngredientID" });
            DropTable("dbo.Meal");
            DropTable("dbo.MealIngredient");
        }
    }
}
