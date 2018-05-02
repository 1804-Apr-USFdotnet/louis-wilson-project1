namespace RestaurantReviews.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Restaurants",
                c => new
                    {
                        RestaurantID = c.Int(nullable: false, identity: true),
                        RestaurantName = c.String(),
                        FoodType = c.String(),
                        AverageRating = c.Double(nullable: false),
                        reviewList_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RestaurantID)
                .ForeignKey("dbo.ReviewLists", t => t.reviewList_ID, cascadeDelete: true)
                .Index(t => t.reviewList_ID);
            
            CreateTable(
                "dbo.ReviewLists",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        avgScore = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ReviewerName = c.String(),
                        Rating = c.Double(nullable: false),
                        Description = c.String(),
                        reviewDate = c.DateTime(nullable: false),
                        ReviewList_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ReviewLists", t => t.ReviewList_ID)
                .Index(t => t.ReviewList_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Restaurants", "reviewList_ID", "dbo.ReviewLists");
            DropForeignKey("dbo.Reviews", "ReviewList_ID", "dbo.ReviewLists");
            DropIndex("dbo.Reviews", new[] { "ReviewList_ID" });
            DropIndex("dbo.Restaurants", new[] { "reviewList_ID" });
            DropTable("dbo.Reviews");
            DropTable("dbo.ReviewLists");
            DropTable("dbo.Restaurants");
        }
    }
}
