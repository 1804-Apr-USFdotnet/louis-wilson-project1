namespace RestaurantReviews.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LocationObj : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StreetNumber = c.Int(nullable: false),
                        StreetName = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Zipcode = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Restaurants", "restaurantLocation_ID", c => c.Int(nullable: false));
            CreateIndex("dbo.Restaurants", "restaurantLocation_ID");
            AddForeignKey("dbo.Restaurants", "restaurantLocation_ID", "dbo.Locations", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Restaurants", "restaurantLocation_ID", "dbo.Locations");
            DropIndex("dbo.Restaurants", new[] { "restaurantLocation_ID" });
            DropColumn("dbo.Restaurants", "restaurantLocation_ID");
            DropTable("dbo.Locations");
        }
    }
}
